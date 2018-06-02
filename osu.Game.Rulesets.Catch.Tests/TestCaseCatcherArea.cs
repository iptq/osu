﻿// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System;
using System.Collections.Generic;
using NUnit.Framework;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.Catch.UI;
using osu.Game.Tests.Visual;

namespace osu.Game.Rulesets.Catch.Tests
{
    [TestFixture]
    public class TestCaseCatcherArea : OsuTestCase
    {
        private RulesetInfo catchRuleset;

        public override IReadOnlyList<Type> RequiredTypes => new[]
        {
            typeof(CatcherArea),
        };

        public TestCaseCatcherArea()
        {
            AddSliderStep<float>("CircleSize", 0, 8, 5, createCatcher);
        }

        private void createCatcher(float size)
        {
            Child = new CatchInputManager(catchRuleset)
            {
                RelativeSizeAxes = Axes.Both,
                Child = new TestCatcherArea(new BeatmapDifficulty { CircleSize = size })
                {
                    Anchor = Anchor.CentreLeft,
                    Origin = Anchor.TopLeft
                },
            };
        }

        [BackgroundDependencyLoader]
        private void load(RulesetStore rulesets)
        {
            catchRuleset = rulesets.GetRuleset(2);
        }

        private class TestCatcherArea : CatcherArea
        {
            public TestCatcherArea(BeatmapDifficulty beatmapDifficulty)
                : base(beatmapDifficulty)
            {
            }
        }
    }
}
