using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//these are necessary to allow for you to do most anything you need within your component
using LiveSplit.Model;
using LiveSplit.Model.Input;
using LiveSplit.ComponentTutorial;
using ComponentTutorial;
using LiveSplit.UI.Components;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.IO.MemoryMappedFiles;
using HPdata;

namespace LiveSplit.UI.Components
{
    public class AutoSplitterComponent : UI.Components.LogicComponent
    {
        private Settings settings;

        private readonly TimerModel timer;
        private readonly LiveSplitState state;

        private readonly MemoryMappedFile MemoryFile = MemoryMappedFile.CreateOrOpen("HousePartyMemoryFile", 1024);
        private readonly MemoryMappedViewAccessor Accessor;
        private Data SharedData;
        private bool RunStarted = false;

        //create a constructor for this class that includes an argument for LiveSplits State
        public AutoSplitterComponent(LiveSplitState state)
        {
            //get the state from the factory
            this.state = state;

            //create a new settings object for this component as each one will need its own settings
            settings = new Settings(state);

            Accessor = MemoryFile.CreateViewAccessor();

            state.CurrentTimingMethod = TimingMethod.GameTime;
            state.IsGameTimeInitialized = true;

            //split by increasing split index, start by calling run

        }

        //make sure this matches the factory
        //this should really only be read-only
        public override string ComponentName => "HPspeed";

        //this function gets the settings from the settings user control and puts them in the layout file for livesplit
        public override XmlNode GetSettings(XmlDocument document)
        {
            return settings.GetSettings(document);
        }

        //this gets teh user control to be displayed in livesplit
        public override Control GetSettingsControl(LayoutMode mode)
        {
            return settings;
        }

        //this method sets the settings for the component that were saved to the layout file
        public override void SetSettings(XmlNode settings)
        {
            this.settings.SetSettings(settings);
        }

        //this update funciton updates the component, not much I need to do here but feel free to experiment with this
        public override void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
        {
            Accessor.Read(0, out SharedData);

            state.SetGameTime(new TimeSpan(0, 0, 0, 0, (int)(SharedData.Time * 1000)));

            if (SharedData.PlayerMoved && !RunStarted && SharedData.GameMain)
            {
                _ = state.Run;
                RunStarted = true;
            }

            if (SharedData.AmyTopless && state.CurrentSplitIndex == -1)
            {
                state.CurrentSplitIndex += 1;
            }

        }


        //when implementing the interface, have visual studio create this for you, by selecting implement interface with dispose pattern(the last option)
        //this function gets rid of objects that aren't being used, like when the component is closed
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                disposedValue = true;
            }
        }

        public override void Dispose()
        {
            this.Dispose();
        }
    }
}
