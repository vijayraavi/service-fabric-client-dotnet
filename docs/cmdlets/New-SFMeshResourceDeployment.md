# New-SFMeshResourceDeployment
## Description

## Required Parameters
#### -ResourceDescriptionList
Resource Description Files, which is a list of yaml definitions for the resources.
## Optional Parameters
#### -DefaultParameterFileName
Path to default parameter file containing parameter values to be replaced in the yamls. Values to be parameterised are specified in yaml files as "[parameters('ParamName')]".
#### -ParameterFileName
List of path to parameter file containing parameter values to be replaced in the yamls. Values to be parameterised are specified in yaml files as "[parameters('ParamName')]".
#### -SecretsParameterFileName
List of path to secrets parameter file containing parameter values to be replaced in the yamls. Values to be parameterised are specified in yaml files as "[parameters('ParamName')]".
#### -OutputDirectory
Output directory for the generated resource descriptions.
