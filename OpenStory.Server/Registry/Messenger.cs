﻿using System;

namespace OpenStory.Server.Registry
{
    internal class Messenger : IMessenger
    {
        private int memberCount;
        private MessengerMember[] members;
        private Action onClose;

        private Messenger()
        {
            this.members = new MessengerMember[] { null, null, null };
        }

        public Messenger(int id, MessengerMember initiator, Action onClose)
            : this()
        {
            if (initiator == null) throw new ArgumentNullException("initiator");
            if (onClose == null) throw new ArgumentNullException("onClose");

            this.Id = id;
            this.SetPosition(0, initiator);
            this.onClose = onClose;
        }

        #region IMessenger Members

        public int Id { get; private set; }

        public int MemberCount
        {
            get { return this.memberCount; }
            private set
            {
                this.memberCount = value;
                if (value == 0)
                {
                    this.onClose.Invoke();
                }
            }
        }

        public void AddMember(MessengerMember member)
        {
            if (member == null) throw new ArgumentNullException("member");

            int position = this.GetFreePosition();
            if (position == -1) throw new InvalidOperationException("This messenger is full.");

            this.SetPosition(position, member);
            this.MemberCount++;
        }

        public void RemoveMember(MessengerMember member)
        {
            int position = member.Position;
            this.SetPosition(position, null);
            this.MemberCount--;
        }

        public bool Equals(IMessenger other)
        {
            if (other == null) return false;
            return this.Id == other.Id;
        }

        #endregion

        private int GetFreePosition()
        {
            for (int i = 0; i < 3; i++)
            {
                if (this.members[i] == null) return i;
            }
            return -1;
        }

        private void SetPosition(int i, MessengerMember member)
        {
            this.members[i] = member;
        }
    }
}