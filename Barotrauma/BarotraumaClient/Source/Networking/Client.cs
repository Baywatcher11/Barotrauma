﻿using Barotrauma.Sounds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barotrauma.Networking
{
    partial class Client
    {
        public VoipSound VoipSound
        {
            get;
            private set;
        }

        public void UpdateVoicePosition()
        {
            if (character != null)
            {
                VoipSound.SetPosition(new Microsoft.Xna.Framework.Vector3(character.Position.X, character.Position.Y, 0.0f));
            }
        }

        partial void InitVoipProjSpecific()
        {
            if (GameMain.Client != null)
            {
                GameMain.Client.VoipClient.RegisterQueue(VoipQueue);
            }
            VoipSound = new VoipSound(GameMain.SoundManager,VoipQueue);
        }

        partial void DisposeProjSpecific()
        {
            if (GameMain.Client != null)
            {
                GameMain.Client.VoipClient.UnregisterQueue(VoipQueue);
            }
            if (VoipSound != null)
            {
                VoipSound.Dispose();
                VoipSound = null;
            }
        }
    }
}