# Dotnet NLayer Web Api Example

## Purpose
Make a web api example with best practices of ef core, generic repository design pattern, unit of work design pattern.  
This project has examples about;
1. Generic repository design pattern  
2. Unit of work design pattern  
3. Entity framework core  
4. Custom Validation  
5. Automapper  
6. In memory caching
7. Global error handling

## Design of solution
Core -> Repository -> Service -> (Caching) -> Api  
Layers serve to next layer.

## Layers
- Core  
- Repository  
- Service  
- Caching  
- Api  

### General informations about layers
*You can find detailed informations about layers in projects.*  

1. Core Layer ([Details](https://github.com/burakbozb1/Dotnet-NLayerWebApiExample/blob/master/NLayer.Core/README.md))  
This is a class library and core of the solution. It includes entity models, data tranfer models and common interfaces. Our entites are categories, products and product features. Category has many products. Products has one product feature.

2. Repository Layer ([Details](https://github.com/burakbozb1/Dotnet-NLayerWebApiExample/blob/master/NLayer.Repository/README.md))   
This is a class library. This layer deals with database. It includes database context, model configuration, migrations and implementation of unit of work design pattern.  

3. Service Layer ([Details](https://github.com/burakbozb1/Dotnet-NLayerWebApiExample/blob/master/NLayer.Service/README.md))  
This is a class library. It serves data to web api. All bussiness processes are in this layer. Global exception handling, mapping and validations are in this layer.

4. API ([Details](https://github.com/burakbozb1/Dotnet-NLayerWebApiExample/blob/master/Nlayer.Api/README.md))   
This is a web api project. It is a door to the outside. It takes requests and creates responses. This layer has controllers, filters and middlewares.

5. Caching (In-Memory Caching) ([Details](https://github.com/burakbozb1/Dotnet-NLayerWebApiExample/blob/master/Nlayer.Caching/README.md))   
This is a class library. This layer caches some selected datas. When API project gets request about that selected data, it goes to caching layer. If caching layer has that data, it serves to api. If it has not data, it goes to service layer, gets data, caches data then serves to api.  

