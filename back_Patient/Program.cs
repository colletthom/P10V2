using back_Patient.Data;
using back_Patient.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));


/*builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();*/


//début authent
//builder.Services.AddAuthorization();
/*
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
    options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
})
.AddCookie(IdentityConstants.ApplicationScheme);*/
/*   .AddBearerToken(IdentityConstants.BearerScheme);*/
/*builder.Services.AddIdentityCore<IdentityUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddApiEndpoints();
//fin authent
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});*/

/*builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();*/
/*builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme)
    .AddIdentityCookies();
builder.Services.AddAuthorizationBuilder();
builder.Services.AddIdentityCore<IdentityUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddApiEndpoints();*/

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<PatientService>();
          //      .AddRequiredScopeOrAppPermissionAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.MapIdentityApi<IdentityUser>(); //nécessaire pour configurer
//les points de terminaison API d'authentification et d'autorisation pour votre application.

//app.UseHttpsRedirection();
//app.UseAuthentication(); //nécessaire pour activer le middleware d'authentification
//dans votre application, qui permettra de vérifier les cookies d'authentification envoyés par le client.

//app.UseAuthorization(); // nécessaire pour activer le middleware d'autorisation dans votre
// application, qui permettra de vérifier si l'utilisateur est autorisé à accéder aux ressources protégées.
//app.MapIdentityApi<IdentityUser>();
//optionnel
/*app.MapGet("user", async (ClaimsPrincipal claims, UserManager<IdentityUser> userManager) =>
{
    string userId = claims.Claims.First(c=>c.Type == ClaimTypes.NameIdentifier).Value;
    var user = await userManager.FindByIdAsync(userId);
    return new
    {
        Id = user.Id,
        UserName = user.UserName,
        Email = user.Email,
        // Autres informations d'utilisateur que vous souhaitez inclure
    };
})
    .RequireAuthorization();*/
//app.UseCookiePolicy();
//app.UseAuthentication();

app.MapControllers();

app.Run();

