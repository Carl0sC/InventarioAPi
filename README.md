Guía de Instalación y Despliegue

Esta guía detalla los pasos necesarios para instalar y desplegar la API de inventario y la aplicación frontend. 
Sigue estos pasos para configurar tu entorno de desarrollo y poner en marcha la aplicación.

Crea una base de datos llamada ProductInventoryDB

Abre el archivo appsettings.json en el directorio del proyecto.

Configura la cadena de conexión en la sección ConnectionStrings:

"ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=ProductInventoryDB;User Id=your_user;Password=your_password;"
}

 Aplicar Migraciones
Aplica las migraciones para crear las tablas en la base de datos:

dotnet ef database update

La API estará disponible en http://localhost:5021 por defecto.

Inserta estos datos de ejemplo

INSERT INTO Products (Name, ManufacturingType, State)
VALUES 
    ('Cotton Fabric', 0, 1), -- 0 = ManufacturingType.Handmade, 1 = State.Available
    ('Silk Fabric', 1, 1),   -- 1 = ManufacturingType.HandAndMachineMade, 1 = State.Available
    ('Linen Fabric', 0, 1),  -- 0 = ManufacturingType.Handmade, 1 = State.Available
    ('Wool Fabric', 1, 1),   -- 1 = ManufacturingType.HandAndMachineMade, 1 = State.Available
    ('Polyester Fabric', 0, 1), -- 0 = ManufacturingType.Handmade, 1 = State.Available
    ('Rayon Fabric', 1, 1),  -- 1 = ManufacturingType.HandAndMachineMade, 1 = State.Available
    ('Velvet Fabric', 0, 1), -- 0 = ManufacturingType.Handmade, 1 = State.Available
    ('Denim Fabric', 1, 1),  -- 1 = ManufacturingType.HandAndMachineMade, 1 = State.Available
    ('Satin Fabric', 0, 1),  -- 0 = ManufacturingType.Handmade, 1 = State.Available
    ('Chiffon Fabric', 1, 1);-- 1 = ManufacturingType.HandAndMachineMade, 1 = State.Available


Inicia La Api.


*-----------------------------*---------------------------------------------------------*

(post) http://localhost:5021/api/auth/login  -Token de login 
(get) http://localhost:5021/api/products     -Obtener productos
(delete) http://localhost:5021/api/products/4   -Eliminar prodcutos por id 


-----------------------------------------------------------------------------------

Usuario y contraseña del login

test
password 
