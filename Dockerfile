# syntax=docker/dockerfile:1

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

SHELL ["powershell"]

# Install chocolatey
RUN Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))
RUN choco feature enable -n allowGlobalConfirmation
ENV chocolateyUseWindowsCompression false

RUN choco install -y -r --no-progress --ignore-package-exit-codes=3010 MsSqlServerManagementStudio2014Express
RUN choco install -y -r --no-progress --ignore-package-exit-codes=3010 dotnet
#RUN choco install -y -r --no-progress --ignore-package-exit-codes=3010 visualstudio2019buildtools 

WORKDIR ./customer-contacts/SEB.Customer.Contact

ADD ./SEB.Customer.Contact .

ENTRYPOINT ["dotnet", "Customer.GatewaySolution.dll"]
ENTRYPOINT ["dotnet", "Customer.Services.ContactAPI.dll"]
