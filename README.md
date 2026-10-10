# Vehicle Rental Management

A Windows Forms desktop application for tracking customers, vehicles, rental agreements, and completed rental transactions. The application interface is in Turkish.

## Features

- Register and list customers.
- Register vehicles and manage vehicle records.
- Select available vehicles when preparing a rental agreement.
- Look up customers by identity number.
- Calculate rental charges from the rental period and selected pricing.
- Record rental agreements and view completed transactions.

## Technology

- C# and Windows Forms
- .NET Framework 4.7.2
- PostgreSQL accessed through Npgsql
- Visual Studio solution: `AracKiralama.sln`

## Getting started

1. Clone the repository and open `AracKiralama.sln` in Visual Studio on Windows.
2. Install the .NET desktop development workload and the .NET Framework 4.7.2 targeting pack.
3. Restore the NuGet packages.
4. Create a local PostgreSQL database matching the table and column names used by the forms. A database dump or schema creation script is not included.
5. Configure the PostgreSQL connection in `AracKiralama/Arac_Kiralama.cs` for your own local database.
6. Set `AracKiralama` as the startup project and run the application.

The committed database connection is development-specific; replace it with your own configuration before running.

## Source guide

| File | Responsibility |
| --- | --- |
| `Arac_Kiralama.cs` | Database operations and shared lookup helpers |
| `frmAnaSayfa.cs` | Main application window |
| `FrmAraçKayıt.cs` / `frmAraçListele.cs` | Vehicle registration and listing |
| `frmMüsteriEkle.cs` / `frmMüsteriListele.cs` | Customer registration and listing |
| `frmSözleşmecs.cs` | Rental agreement workflow |
| `frmSatış.cs` | Completed transaction listing |

These files are located under `AracKiralama/`.
