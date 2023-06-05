using CareerCloud.Pocos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class CareerCloudContext : DbContext
    {

        public DbSet<ApplicantEducationPoco> ApplicantEducations { get; set; }
        public DbSet<ApplicantJobApplicationPoco> ApplicantJobApplications { get; set;}
        public DbSet<ApplicantProfilePoco> ApplicantProfiles { get; set;}
        public DbSet<ApplicantResumePoco> ApplicantResumes { get; set;}
        public DbSet<ApplicantSkillPoco> ApplicantSkills { get; set;}
        public DbSet<ApplicantWorkHistoryPoco> ApplicantWorkHistories { get; set;}
        public DbSet<CompanyDescriptionPoco> CompanyDescriptions { get; set;}
        public DbSet<CompanyJobDescriptionPoco> CompanyJobDescriptions { get; set;}
        public DbSet<CompanyJobEducationPoco> CompanyJobEducations { get; set;}
        public DbSet<CompanyJobPoco> CompanyJobs { get; set;}
        public DbSet<CompanyJobSkillPoco> CompanyJobSkills { get;set;}
        public DbSet<CompanyLocationPoco> CompanyLocations { get; set;}
        public DbSet<CompanyProfilePoco> CompanyProfiles { get; set;}
        public DbSet<SecurityLoginPoco> SecurityLogins { get; set;}
        public DbSet<SecurityLoginsLogPoco> SecurityLoginsLogs { get; set;}
        public DbSet<SecurityLoginsRolePoco> SecurityLoginsRoles { get; set;}
        public DbSet<SecurityRolePoco> SecurityRoles { get; set;}
        public DbSet<SystemCountryCodePoco> SystemCountryCodes { get; set;}
        public DbSet<SystemLanguageCodePoco> SystemLanguageCodes { get; set;}


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var constr = configuration.GetSection("constr").Value;

            optionsBuilder.UseSqlServer(constr);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicantEducationPoco>(entity =>
            {
                entity.HasOne(e => e.ApplicantProfile)
                .WithMany(e => e.ApplicantEducations)
                .HasForeignKey(e => e.Applicant);
               
            });

            modelBuilder.Entity<ApplicantJobApplicationPoco>()
                .HasOne<ApplicantProfilePoco>(aja => aja.ApplicantProfile)
                .WithMany(AP => AP.ApplicantJobApplications)
                .HasForeignKey(aja => aja.Applicant);


            modelBuilder.Entity<ApplicantJobApplicationPoco>()
                .HasOne<CompanyJobPoco>(aja => aja.CompanyJob)
                .WithMany(CJ => CJ.ApplicantJobApplications)
                .HasForeignKey(aja => aja.Job);

            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasOne<SecurityLoginPoco>(ap => ap.SecurityLogin)
                .WithMany(SL => SL.ApplicantProfiles)
                .HasForeignKey(ap => ap.Login);

            modelBuilder.Entity<ApplicantProfilePoco>()
               .HasOne<SystemCountryCodePoco>(ap => ap.SystemCountryCode)
               .WithMany(CC => CC.ApplicantProfiles)
               .HasForeignKey(ap => ap.Country);

            modelBuilder.Entity<ApplicantResumePoco>()
                .HasOne<ApplicantProfilePoco>(ar => ar.ApplicantProfile)
                .WithMany(AP => AP.ApplicantResumes)
                .HasForeignKey(ar => ar.Applicant);

            modelBuilder.Entity<ApplicantSkillPoco>()
                .HasOne<ApplicantProfilePoco>(sk => sk.ApplicantProfile)
                .WithMany(AP => AP.ApplicantSkills)
                .HasForeignKey(sk => sk.Applicant);

            modelBuilder.Entity<ApplicantWorkHistoryPoco>()
                .HasOne<ApplicantProfilePoco>(wo => wo.ApplicantProfile)
                .WithMany(AP => AP.ApplicantWorkHistorys)
                .HasForeignKey(wo => wo.Applicant);

            modelBuilder.Entity<ApplicantWorkHistoryPoco>()
               .HasOne<SystemCountryCodePoco>(wo => wo.SystemCountryCode)
               .WithMany(AP => AP.ApplicantWorkHistorys)
               .HasForeignKey(wo => wo.CountryCode);

            //////////////////////////////////////////////////////////

            modelBuilder.Entity<CompanyDescriptionPoco>()
               .HasOne<CompanyProfilePoco>(c => c.CompanyProfile)
               .WithMany(CP => CP.CompanyDescriptions)
               .HasForeignKey(c => c.Company);

            modelBuilder.Entity<CompanyDescriptionPoco>()
              .HasOne<SystemLanguageCodePoco>(c => c.SystemLanguageCode)
              .WithMany(LC => LC.CompanyDescriptions)
              .HasForeignKey(c => c.LanguageId);


            modelBuilder.Entity<CompanyJobEducationPoco>()
             .HasOne<CompanyJobPoco>(c => c.CompanyJob)
             .WithMany(LC => LC.CompanyJobEducations)
             .HasForeignKey(c => c.Job);


            modelBuilder.Entity<CompanyJobPoco>()
            .HasOne<CompanyProfilePoco>(c => c.CompanyProfile)
            .WithMany(LC => LC.CompanyJobs)
            .HasForeignKey(c => c.Company);

            modelBuilder.Entity<CompanyJobDescriptionPoco>()
           .HasOne<CompanyJobPoco>(c => c.CompanyJob)
           .WithMany(LC => LC.CompanyJobDescriptions)
           .HasForeignKey(c => c.Job);



            modelBuilder.Entity<CompanyJobSkillPoco>()
            .HasOne<CompanyJobPoco>(c => c.CompanyJob)
            .WithMany(LC => LC.CompanyJobSkills)
            .HasForeignKey(c => c.Job);

            modelBuilder.Entity<CompanyLocationPoco>()
            .HasOne<CompanyProfilePoco>(c => c.CompanyProfile)
            .WithMany(LC => LC.CompanyLocations)
            .HasForeignKey(c => c.Company);

            modelBuilder.Entity<CompanyLocationPoco>()
            .HasOne<SystemCountryCodePoco>(c => c.SystemCountryCode)
            .WithMany(LC => LC.CompanyLocations)
            .HasForeignKey(c => c.CountryCode);

            modelBuilder.Entity<SecurityLoginsLogPoco>()
            .HasOne<SecurityLoginPoco>(c => c.SecurityLogin)
            .WithMany(LC => LC.SecurityLoginsLogs)
            .HasForeignKey(c => c.Login);

            modelBuilder.Entity<SecurityLoginsRolePoco>()
           .HasOne<SecurityLoginPoco>(c => c.SecurityLogin)
           .WithMany(LC => LC.SecurityLoginsRoles)
           .HasForeignKey(c => c.Login);

            modelBuilder.Entity<SecurityLoginsRolePoco>()
         .HasOne<SecurityRolePoco>(c => c.SecurityRole)
         .WithMany(LC => LC.SecurityLoginsRoles)
         .HasForeignKey(c => c.Role);

            

            modelBuilder.Entity<CompanyDescriptionPoco>()
                .Property(e => e.TimeStamp)
                .ValueGeneratedOnAdd()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            modelBuilder.Entity<CompanyJobEducationPoco>()
                .Property(e => e.TimeStamp)
                .ValueGeneratedOnAdd()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            modelBuilder.Entity<CompanyJobSkillPoco>()
                .Property(e => e.TimeStamp)
                .ValueGeneratedOnAdd()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            modelBuilder.Entity<CompanyJobPoco>()
                .Property(e => e.TimeStamp)
                .ValueGeneratedOnAdd()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            modelBuilder.Entity<CompanyJobDescriptionPoco>()
               .Property(e => e.TimeStamp)
               .ValueGeneratedOnAdd()
               .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            modelBuilder.Entity<CompanyLocationPoco>()
              .Property(e => e.TimeStamp)
              .ValueGeneratedOnAdd()
              .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            modelBuilder.Entity<CompanyProfilePoco>()
                .Property(e => e.TimeStamp)
                .ValueGeneratedOnAdd()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            modelBuilder.Entity<SecurityLoginPoco>()
               .Property(e => e.TimeStamp)
               .ValueGeneratedOnAdd()
               .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            modelBuilder.Entity<SecurityLoginsRolePoco>()
               .Property(e => e.TimeStamp)
               .ValueGeneratedOnAdd()
               .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            modelBuilder.Entity<ApplicantEducationPoco>()
              .Property(e => e.TimeStamp)
              .ValueGeneratedOnAdd()
              .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            modelBuilder.Entity<ApplicantJobApplicationPoco>()
              .Property(e => e.TimeStamp)
              .ValueGeneratedOnAdd()
              .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            modelBuilder.Entity<ApplicantProfilePoco>()
              .Property(e => e.TimeStamp)
              .ValueGeneratedOnAdd()
              .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            modelBuilder.Entity<ApplicantSkillPoco>()
              .Property(e => e.TimeStamp)
              .ValueGeneratedOnAdd()
              .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            modelBuilder.Entity<ApplicantWorkHistoryPoco>()
              .Property(e => e.TimeStamp)
              .ValueGeneratedOnAdd()
              .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);



        }




    }
}