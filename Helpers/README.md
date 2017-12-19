# MicroserviceDuplicator

Used to make copies of our microservice prototype, each of the copies having a different name, ex: Temperature -> Pressure.

## Usage:

* cd into the folder containing MicroserviceDuplicator.csproj
* dotnet run <source_root> <destination_root> <source_microservice_name> <destination_microservice_name>

Ex: `dotnet run "C:\Users\Scooby Doo\Desktop\Temperature" "C:\Users\Scooby Doo\Desktop\Pressure" Temperature Pressure`

* build your new solution and you're done

## Obs: 

* the <destination_root> will be created if not already existing.
* <source_microservice_name> and <destination_microservice_name> are case insensitive.
* The program is easily extendable and can be made to work with regular expressions too instead of just a name.
