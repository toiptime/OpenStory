﻿using OpenStory.Common.IO;

namespace OpenStory.Server.Auth
{
    partial class AuthClient
    {
        private bool CheckPin(IUnsafePacketReader reader)
        {
            string suggested = reader.ReadLengthString();
            string expected = this.Account.AccountPin;
            var isValid = suggested == expected;
            return isValid;
        }
    }
}
