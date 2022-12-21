# Repository Layer

This layer is a class library. Repository layer is responsible for database operations. It includes entity configurations, migrations and dbContext. AppDbContext is DbContxt of project. It inherits from DbContext. We create our db set in this db context.  
We have three entity so we have 3 db set object. They are:  
- Categories
- Products
- ProductFeatures  

## How can we configure entities
There are two approachs to configure dbcontext. The first way is that implemet in onModelCreating function in AppDbContext. If you have less entity, you can use this approach like this:  

```csharp
public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { 
        
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //You can configure your model here
            base.OnModelCreating(modelBuilder);
        }
    }
}
```  

I choosed second way. I created a folder named 'Configuration' and I configured my entites in this folder. I have three configuration file in this folder.  
I configured my entites in thoose files and I set OnModelCreating function with that configuration files aseembly.  
My configuration files are:  
**1. Category Configuration**
```csharp
internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.ToTable("Categories");
        }
    }
```  
**2. Product Configuration**
```csharp
internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Stock).IsRequired();
            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.ToTable("Products");
            builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);
        }
    }
```  
**3. ProductFeatureConfiguration**
```csharp
internal class ProductFeatureConfiguration : IEntityTypeConfiguration<ProductFeature>
    {
        public void Configure(EntityTypeBuilder<ProductFeature> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.HasOne(x => x.Product).WithOne(x => x.ProductFeature).HasForeignKey<ProductFeature>(x => x.ProductId);
        }
    }
```  

And my OnModelCreating function in AppDbContext:  
```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
  modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  base.OnModelCreating(modelBuilder);
}
``` 
