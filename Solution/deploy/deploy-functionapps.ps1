<#
.SYNOPSIS
  Deploys the child webjobs/project binaries into azure app service for Momentum External API. Note this script
  requires you to login first into azure account.
.DESCRIPTION
  Deploys the web application binaries into azure app service. If you haven't logged into azure account already,
  execute `Connect-AzAccount` and `Select-AzSubscription -Subscription "XXX"'. Depending on your account,
  you might need to use something like `Connect-AzAccount -Subscription "XXX" -TenantId "1aaaea9d-df3e-4ce7-a55d-43de56e79442"`.
.PARAMETER $PublishedArtifactsPath
  The path of zip package to publish (e.g. "./PublishedArtifacts")
.PARAMETER $WebAppName
  The name of the web application  (e.g. "kmd-momentum-mea-shareddev-webapp")
.PARAMETER $ResourceGroupName
  The name of the resource group to deploy to (e.g. "kmd-momentum-mea-shareddev-rg")
.PARAMETER $AutoSwapSlots
  If set, the deployed "staging" slot will be swapped to become the "production" slot via `deploy-swapslots.ps1`.
.INPUTS
  none
.OUTPUTS
  none
.NOTES
  Version:        1.0
  Author:         Adam Chester
  Creation Date:  22 Nov 2019
  Purpose/Change: Created

.EXAMPLE
  ./deploy-webapps.ps1 -PublishedArtifactsPath ../artifacts -WebAppName kmd-momentum-mea-udvdev-webapp -ResourceGroupName kmd-momentum-mea-udvdev-rg -AutoSwapSlots

  Deploys functions to the `udvdev` environment staging slot from the (relative) artifacts folder and automatically swaps staging to the production slot.
#>
Param(
    [Parameter(Mandatory=$true)]
    [string] $PublishedArtifactsPath,

    [Parameter(Mandatory=$true)]
    [string] $FunctionAppName,

    [Parameter(Mandatory=$true)]
    [string] $ResourceGroupName,

)
try{
    $ErrorActionPreference = "Stop"
    
    $artifactFileName = "Kmd.Momentum.Mea.Funapp.zip"
    $artifactFilePath = "$PublishedArtifactsPath/$artifactFileName"
    $resolvedArtifactFilePath = Resolve-Path -Path "$artifactFilePath"
    
    Write-Host "Puslishing the archive from '$resolvedArtifactFilePath' to the '$FunctionAppName'"
    
    Publish-AzWebapp -Force -ResourceGroupName $ResourceGroupName -Name $FunctionAppName -ArchivePath $resolvedArtifactFilePath
    
    # Verify the newly deployed function is responding
    
    Write-Host "Displaying the last sucessful deployment for $ResourceGroupName"
    
    $lastDeployment = Get-AzResourceGroupDeployment -ResourceGroupName $resourceGroupName | Where-Object {$_.ProvisioningState -eq "Succeeded"} | Sort-Object Timestamp -Descending | Select-Object -First 1
    $lastDeployment

    Write-Host '-------',$lastDeployment
    Write-Host '-------',$lastDeployment
}
catch{
    Write-Host '',"An error occurred:"
    Write-Host '',$_
    Write-Host '',"##vso[task.LogIssue type=error;]"$_
    Write-Host '',"##vso[task.complete result=Failed]"
    exit 1
}