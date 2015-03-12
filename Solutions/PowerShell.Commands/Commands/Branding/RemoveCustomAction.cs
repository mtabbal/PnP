﻿using System.Management.Automation;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.PowerShell.CmdletHelpAttributes;
using OfficeDevPnP.PowerShell.Commands.Base.PipeBinds;
using Resources = OfficeDevPnP.PowerShell.Commands.Properties.Resources;

namespace OfficeDevPnP.PowerShell.Commands
{
    [Cmdlet(VerbsCommon.Remove, "SPOCustomAction", ConfirmImpact = ConfirmImpact.High, SupportsShouldProcess = true)]
    [CmdletHelp("Removes a custom action", Category = "Branding")]
    public class RemoveCustomAction : SPOWebCmdlet
    {
        [Parameter(Mandatory = true, Position=0, ValueFromPipeline=true)]
        public GuidPipeBind Identity;

        [Parameter(Mandatory = false)]
        public SwitchParameter Force;

        protected override void ExecuteCmdlet()
        {
            if (Identity != null)
            {
                if (Force || ShouldContinue(Resources.RemoveCustomAction, Resources.Confirm))
                {
                    SelectedWeb.DeleteCustomAction(Identity.Id);
                }
            }
        }
    }
}
