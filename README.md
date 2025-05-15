# Function App on Container Apps - slow executions test


[![Deploy To Azure](https://raw.githubusercontent.com/Azure/azure-quickstart-templates/master/1-CONTRIBUTION-GUIDE/images/deploytoazure.svg?sanitize=true)](https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2Fgabesmsft%2FFunctionAppSlownessTest%2Fmaster%2Fdeploy%2Fazuredeploy.json)

This sample Azure Resource Manager template deploys a Function App on Container App, using the Container App-only resource (kind=functionapp).

This application is not intended as a production application or as official instructions.

The Slow*x*minuteHttpFunctions use Thread.Sleep to sleep for x number of minutes. You will get an HTTP timeout after ~4 minutes.

- Slow5minuteHttpFunction
- Slow12minuteHttpFunction
- Slow20minuteHttpFunction
- Slow25minuteHttpFunction
- CrashHttpFunction
- FastHttpFunction: demonstrates a function that successfully and quickly executes.