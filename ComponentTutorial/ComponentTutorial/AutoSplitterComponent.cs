using HPdata;
//these are necessary to allow for you to do most anything you need within your component
using LiveSplit.Model;
using System;
using System.IO.MemoryMappedFiles;
using System.Windows.Forms;
using System.Xml;

namespace LiveSplit.UI.Components
{
    public class AutoSplitterComponent : UI.Components.LogicComponent
    {
        private readonly Settings settings;

        private readonly TimerModel timer;
        private readonly LiveSplitState state;
        private float Time;

        private readonly MemoryMappedFile MemoryFile = MemoryMappedFile.CreateOrOpen("HousePartyMemoryFile", 2048);
        private readonly MemoryMappedViewAccessor Accessor;
        public Data SharedData = new Data();
        private bool RunStarted = false;
        private enum CategoryE
        {
            TOPLESSAmy,
            TOPLESSAshley,
            TOPLESSBrittney,
            TOPLESSKatherine,
            TOPLESSLeah,
            TOPLESSLety,
            TOPLESSMadison,
            TOPLESSRachael,
            TOPLESSStephanie,
            TOPLESSVickie,
            ALLREWARDS14,
            ALLREWARDS15,
            ALLREWARDS16,
            ALLREWARDS17,
            ALLREWARDS18,
            ALLREWARDS19,
            ALLREWARDS20,
            REWARDAmy,
            REWARDAshley,
            REWARDDerek,
            REWARDFrank,
            REWARDKatherine,
            REWARDLeah,
            REWARDLety,
            REWARDMadison,
            REWARDPatrick,
            REWARDRachael,
            REWARDStephanie,
            REWARDVickie,
            THREESOME20
        };

        //create a constructor for this class that includes an argument for LiveSplits State
        public AutoSplitterComponent(LiveSplitState state)
        {
            //get the state from the factory
            this.state = state;

            //create a new settings object for this component as each one will need its own settings
            settings = new Settings(state);

            //get timer from state
            timer = new TimerModel { CurrentState = state };

            timer.OnStart += OnTimerStart;
            timer.OnPause += OnTimerPause;

            state.CurrentTimingMethod = TimingMethod.GameTime;
            Accessor = MemoryFile.CreateViewAccessor();
            if (Accessor.CanRead)
            {
                state.IsGameTimeInitialized = true;
                Accessor.Read(0, out SharedData);
            }
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

            //System.Diagnostics.Debug.Write(SharedData.ToString());

            if (SharedData.InMenu ==  0 && SharedData.PlayerMoved == 1 && SharedData.GameMain == 1)
            {
                System.Diagnostics.Debug.Write(Time.ToString());
                if (!RunStarted)
                {
                    state.IsGameTimeInitialized = true;
                    Time = 0f;
                    _ = state.Run;
                    RunStarted = true;
                    timer.Start();
                    state.SetGameTime(new TimeSpan(0, 0, 0, 0, (int)(Time * 1000)));
                }
                else
                {
                    Time += SharedData.DeltaTime;
                    state.SetGameTime(new TimeSpan(0, 0, 0, 0, (int)(Time * 1000)));
                }
            }
            else
            {
                state.SetGameTime(new TimeSpan(0, 0, 0, 0, (int)(Time * 1000)));
            }

            //amy topless%
            if (SharedData.AmyTopless == 1 && settings.Category == (int)CategoryE.TOPLESSAmy)
            {
                timer.Split();
            }
            //ashley topless%
            if (SharedData.AshleyTopless == 1 && settings.Category == (int)CategoryE.TOPLESSAshley)
            {
                timer.Split();
            }
            //Brittney topless%
            if (SharedData.BrittneyTopless == 1 && settings.Category == (int)CategoryE.TOPLESSBrittney)
            {
                timer.Split();
            }
            //Katherine topless%
            if (SharedData.KatherineTopless == 1 && settings.Category == (int)CategoryE.TOPLESSKatherine)
            {
                timer.Split();
            }
            //Madison topless%
            if (SharedData.MadisonTopless == 1 && settings.Category == (int)CategoryE.TOPLESSMadison)
            {
                timer.Split();
            }
            //Leah topless%
            if (SharedData.LeahTopless == 1 && settings.Category == (int)CategoryE.TOPLESSLeah)
            {
                timer.Split();
            }
            //Lety topless%
            if (SharedData.LetyTopless == 1 && settings.Category == (int)CategoryE.TOPLESSLety)
            {
                timer.Split();
            }
            //Rachael topless%
            if (SharedData.RachaelTopless == 1 && settings.Category == (int)CategoryE.TOPLESSRachael)
            {
                timer.Split();
            }
            //Stephanie topless%
            if (SharedData.StephanieTopless == 1 && settings.Category == (int)CategoryE.TOPLESSStephanie)
            {
                timer.Split();
            }
            //Vickie topless%
            if (SharedData.VickieTopless == 1 && settings.Category == (int)CategoryE.TOPLESSVickie)
            {
                timer.Split();
            }
        }

        private void OnTimerStart(object sender, EventArgs e)
        {

        }

        private void OnTimerPause(object sender, EventArgs e)
        {

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
