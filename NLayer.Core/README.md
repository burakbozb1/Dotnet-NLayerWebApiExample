# Core Layer
**Core Layer** -> Repository Layer -> Service Layer -> (Caching Layer) -> Api Layer  
This layer is a class library. It is main project of solution. This project includes entity models, data transfer models and common interfaces.  
Our entites are categories, products and product features. Category has many products. Each product has one product feature. Our entites are:   
1. Base Entity: This entity has the common properties. Other entites inherits from base entity. This is an abstract class.  
```csharp
public abstract class BaseEntity
{
  public int Id { get; set; }
  public DateTime CreatedDate { get; set; }
  public DateTime? UpdatetDate { get; set; }
}
```
2. Category:  
```csharp
public class Category:BaseEntity
{
  public string Name { get; set; }
  public ICollection<Product> Products { get; set; }
}
```
3. Product:  
```csharp
public class Product:BaseEntity
{
  public string Name { get; set; }
  public int Stock { get; set; }
  public decimal Price { get; set; }
  public int CategoryId { get; set; }
  public Category Category { get; set; }
  public ProductFeature ProductFeature { get; set; }
}
```
4. Product Feature:  
```csharp
public class ProductFeature
{
  public int Id { get; set; }
  public string Color { get; set; }
  public int Height { get; set; }
  public int Width { get; set; }
  public int ProductId { get; set; }
  public Product Product { get; set; }
}
```  

Interfaces are:
- IGenericRepository
- ICategoryRepository
- IProductRepository
- IService
- IProductService
- ICategoryService
- IUnitOfWork  

Generic repository and service interfaces include standard crud functions. Other service and repository interfaces inherit from generic ones and they include specific functions.  
IUnitOfWork interface includes two functions. First is async commit and commit. Main purpose of using unit of work design pattern is that we can do a lot of changes in our db context object with one transaction. If we do not use this pattern, we have to commit to database for all operations each by. 
