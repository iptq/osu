// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Screens;
using osu.Game.Screens.Play;

namespace osu.Game.Screens.Edit
{
    public class EditorPlayer : Player
    {
        public EditorPlayer()
            : base(new PlayerConfiguration { ShowResults = false })
        {
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();
            ScoreProcessor.HasCompleted.BindValueChanged(completed =>
            {
                if (completed.NewValue)
                    Scheduler.AddDelayed(this.Exit, RESULTS_DISPLAY_DELAY);
            });
        }

        protected override void PrepareReplay()
        {
            // don't record replays.
        }

        protected override bool CheckModsAllowFailure() => false; // never fail.
    }
}
