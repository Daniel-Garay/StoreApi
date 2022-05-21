# Prueba de ingreso Aranda Software

![enter image description here](https://i.postimg.cc/906RHhfH/logo-Aranda.png)


## Existe un catálogo de productos que cuenta con las siguientes características:
- Nombre
- Descripción breve
- Categoría
- Imagen del producto

## Desarrolle una API Restful que permita:
1. Crear un nuevo producto
2. Modificar un producto existente
3. Borrar un producto existente
4. Listar los productos existentes teniendo en cuenta que se puede buscar por:

- Nombre
- Descripción.
- Categoría

Es necesario que se puedan ordenar los resultados de forma ascendente o
descendente ya sea por nombre o por categoría.

Tenga en cuenta que el catálogo de productos puede crecer, hasta llegar a tener más de 100 mil registros.

## Tenga en cuenta los siguientes requerimientos técnicos:

- Lenguaje C# (net framework 4.7+)
- La base de datos debe ser SQL server 2014+
- Usar Entity Framework como ORM
- Deben reflejarse los principios RestFul en el API
- Usar una arquitectura claramente definida (3 capas / dominio).
- Debe usarse inyección de dependencias.
- Debe existir evidencia del manejo de errores.
- Entregar el código fuente en un repositorio de Git (público), o en su defecto, un
archivo ZIP.


# Entregable

###  Consulta de catalogo:

Verbo Http : GET
Url : https://localhost:7206/GetCatalog
####  Query Parameters:
  
                    -  orderByProduct => Enumerable => category_desc, category_asc,  name_desc,  name_asc,
                    -  description
                    -  category
                    -  from
                    -  name
                    -  maxPageSize

Response Status: 200 OK

Lista de productos
```json
[
    {
        "id": 132,
        "name": "Airpods",
        "description": "AirPods con estuche de carga - Blanco",
        "category": "Aple",
        "creationDate": "2022-05-20T21:37:29.15"
    },
    {
        "id": 133,
        "name": "Mac",
        "description": "Computadora Mac",
        "category": "Aple",
        "creationDate": "2022-05-20T23:50:38.397"
    }
]
```

###  Creación de producto:

Verbo Http : POST
Url : https://localhost:7206/CreateProduct


Request CreateProduct

```json
{
  "name": "iPhone",
  "description": "Celular iPhone",
  "Category": "Aple"
}
```



Response Status: 200 OK

Producto Creado
```json

{
    "id": 142,
    "name": "iPhone negro ",
    "description": "Celular iPhone negro",
    "category": "Aple",
    "creationDate": "0001-01-01T00:00:00"
}

```


#### Tecnología Utilizada
- .Net Core
-  ApiRest
-  Dynamo DB
