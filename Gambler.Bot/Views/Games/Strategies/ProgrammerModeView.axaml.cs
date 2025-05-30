using Avalonia.Controls;
using Avalonia.Platform.Storage;
using Avalonia.ReactiveUI;
using AvaloniaEdit;
using AvaloniaEdit.TextMate;
using Gambler.Bot.Classes;
using Gambler.Bot.ViewModels.Common;
using Gambler.Bot.ViewModels.Strategies;
using ReactiveUI;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;
using System.Web;
using TextMateSharp.Grammars;

namespace Gambler.Bot.Views.Games.Strategies
{
    public partial class ProgrammerModeView : ReactiveUserControl<ProgrammerModeViewModel>
    {
        public ProgrammerModeView()
        {
            InitializeComponent();

            this.WhenActivated(d =>
            { 
                ViewModel.SaveFileInteraction.RegisterHandler(SaveFile);
                ViewModel.OpenFileInteraction.RegisterHandler(OpenFile);
            });

        }

        async Task SaveFile(IInteractionContext<FilePickerSaveOptions, string?> interaction)
        {
            await IOHelper.SaveFile(interaction, TopLevel.GetTopLevel(this));
        }

        async Task OpenFile(IInteractionContext<FilePickerOpenOptions, string?> interaction)
        {
            await IOHelper.OpenFile(interaction, TopLevel.GetTopLevel(this));
        }
    }
}
