using HexagonalFromScratch.Domain;
using HexagonalFromScratch.Infra;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace HexagonalFromScratch.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            var requestVersesJsonAdapter = InstantiateAFullHexagon();

            // All our application will keep in its hands is the Left-side adapter
            // This is the one that our web controller will need to get injected with.
            services.AddSingleton<RequestVersesJsonAdapter>(requestVersesJsonAdapter);

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info {Title = "My API", Version = "v1"}); });
        }

        private static RequestVersesJsonAdapter InstantiateAFullHexagon()
        {
            // Step1: Instantiate the ("I want to go out") right-side adapters
            var poemFileAdapter = new PoemFileAdapter(@".\Rimbaud.txt");

            // Step2: Instantiate the Hexagon
            var hexagon = new PoetryReader(poemFileAdapter);

            // Step3: Instantiate the ("I want to go in") left-side adapters
            var requestVersesJsonAdapter = new RequestVersesJsonAdapter(hexagon);
            return requestVersesJsonAdapter;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc();
        }
    }
}