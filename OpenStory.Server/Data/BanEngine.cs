﻿using System;
using System.Data;
using System.Data.SqlClient;
using OpenStory.Common;

namespace OpenStory.Server.Data
{
    internal class BanEngine
    {
        public static readonly DateTimeOffset NoExpiration = DateTimeOffset.MaxValue;

        public static void BanByAccountId(int accountId, string reason)
        {
            BanByAccountId(accountId, reason, NoExpiration);
        }

        public static void BanByAccountId(int accountId, string reason, DateTimeOffset expiration)
        {
            using (SqlCommand command = new SqlCommand("up_BanAccountById"))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 60;
                command.Parameters.Add("@AccountId", SqlDbType.Int).Value = accountId;
                command.Parameters.Add("@BanReason", SqlDbType.VarChar, 50).Value = reason;
                command.Parameters.Add("@ExpirationData", SqlDbType.DateTimeOffset, 7).Value = expiration;
                DbHelpers.ExecuteNonQuery(command);
            }
        }
    }

    /// <summary>
    /// The type of a ban.
    /// </summary>
    [Serializable]
    public enum BanType : byte
    {
        /// <summary>
        /// Default value.
        /// </summary>
        None = 0,
        /// <summary>
        /// The user is banned by their account ID. They will be able to access other accounts.
        /// </summary>
        AccountId = 1,
        /// <summary>
        /// The user is banned by their current IP address. They will be able to access the game if their IP address changes.
        /// </summary>
        IpAddress = 2,
        /// <summary>
        /// The user is banned by their physical device address. They will be able to access the game if they use another device.
        /// </summary>
        MacAddress = 3,
        /// <summary>
        /// The user is banned by their hard drive's Serial ID. They will be able to access the game from a machine with a different one.
        /// </summary>
        VolumeSerialId = 4
    }
}