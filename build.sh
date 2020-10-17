cd src
dotnet build
mv bin/Debug/netcoreapp3.1/* ../build
rmdir bin/Debug/netcoreapp3.1
rmdir bin/Debug
rmdir bin
cd ../