using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSanta
{
    class Program
    {
        static void Main(string[] args)
        {
            List<SecretSantaParticipant> participants = new List<SecretSantaParticipant>();
            Console.WriteLine("To run a Secret Santa, please enter the names of your participants below. One name per line.");
            int next_id = 0;
            while(true){
                string next = Console.ReadLine();

                if(next == "")
                {
                    break;
                }

                else
                {
                    SecretSantaParticipant p = new SecretSantaParticipant(next, next_id);
                    participants.Add(p);
                    next_id++;
                }
            }

            Console.WriteLine("Beginning to calculate matches...");
            CalculateMatchings(participants);
            Console.ReadLine();
        }

        private static void CalculateMatchings(List<SecretSantaParticipant> participants)
        {
            List<SecretSantaParticipant> noSanta = new List<SecretSantaParticipant>(participants);
            List<SecretSantaParticipant> noReceiver = new List <SecretSantaParticipant> (participants);
            Random rn = new Random();

            while(noSanta.Count > 0 || noReceiver.Count > 0)
            {
                bool unique = false;
                SecretSantaParticipant santa = null;
                SecretSantaParticipant receiver = null;

                while (unique == false)
                {
                    int santaIndex = rn.Next(noReceiver.Count);
                    int receiverIndex = rn.Next(noSanta.Count);

                    santa = noReceiver[santaIndex];
                    receiver = noSanta[receiverIndex];

                    if(santa.SantaID != receiver.SantaID)
                    {
                        unique = true;
                    }
                }
                

                receiver.setSanta(santa);
                santa.setReceiver(receiver);

                Console.WriteLine(santa.getName() +"(ID:"+santa.SantaID+")" + " -> " + receiver.getName() + "(ID:"+receiver.SantaID+")");

                noSanta.Remove(receiver);
                noReceiver.Remove(santa);
            }
        }
    }
}
