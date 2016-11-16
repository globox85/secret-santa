namespace SecretSanta
{
    internal class SecretSantaParticipant
    {
        private string name;
        private SecretSantaParticipant receiver, santa;
        private bool hasSanta = false;
        private bool hasReceiver = false;
        public bool HasSanta
        {
            get
            {
                return hasSanta;
            }

            set
            {
                hasSanta = value;
            }
        }
        public bool HasReceiver
        {
            get
            {
                return hasReceiver;
            }
            set
            {
                hasReceiver = value;
            }
        }
        public SecretSantaParticipant(string n)
        {
            name = n;
        }

        public string getName()
        {
            return name;
        }

        public void setName(string n)
        {
            name = n;
        }

        public SecretSantaParticipant getSanta()
        {
            return santa;
            
        }

        public void setSanta(SecretSantaParticipant s)
        {
            santa = s;
            hasSanta = true;
        }

        public void setReceiver(SecretSantaParticipant g)
        {
            receiver = g;
            hasReceiver = true;
        }
        
    }
}