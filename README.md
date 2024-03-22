# Function App on Container Apps - slow executions test


[![Deploy To Azure](https://raw.githubusercontent.com/Azure/azure-quickstart-templates/master/1-CONTRIBUTION-GUIDE/images/deploytoazure.svg?sanitize=true)](https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2Fgabesmsft%2FFunctionAppSlownessTest%2Fmaster%2Fdeploy%2Fazuredeploy.json)

This sample Azure Resource Manager template deploys a Container App Environment and Function App on Container App.

This application is only for testing logging when the Function App takes x number of minutes to complete and is not intended as a production application or as official instructions.

The Slow*x*minuteHttpFunctions use Thread.Sleep to sleep for x number of minutes.

- Slow5minuteHttpFunction: doesn't include a logging statement after the Thread.Sleep
- Slow12minuteHttpFunction: doesn't include a logging statement after the Thread.Sleep
- Slow20minuteHttpFunction: doesn't include a logging statement after the Thread.Sleep
- Slow25minuteHttpFunction: logs "Slow25MinuteHttpFunction execution completed." after the Thread.Sleep
- CrashHttpFunction: demonstrates a crash. The Function execution should complete with a failure when executed.
- FastHttpFunction: demonstrates a function that successfully and quickly executes.