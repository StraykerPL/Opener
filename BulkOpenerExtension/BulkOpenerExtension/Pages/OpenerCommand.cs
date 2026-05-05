using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;
using Opener.Models;
using Opener.Services;

namespace BulkOpenerExtension.Pages
{
    public partial class OpenerCommand : InvokableCommand
    {
        private readonly IOpenerService _openerService;

        public OpenerCommand()
            : this(OpenerServiceFactory.CreateDefault())
        {
        }

        public OpenerCommand(IOpenerService openerService)
        {
            _openerService = openerService;
            Name = "Do it";
            Icon = new("\uE945");
        }

        public override ICommandResult Invoke()
        {
            _openerService.Open(new OpenerConfiguration());

            return CommandResult.Hide();
        }
    }
}
