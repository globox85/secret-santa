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

            SantaLoop();
            
        }

        private static void SantaLoop()
        {
            List<SecretSantaParticipant> participants = new List<SecretSantaParticipant>();
            Console.WriteLine("Enter commands below:");
            int next_id = 0;
            bool loop_running = true;
            while (loop_running)
            {
                string command = Console.ReadLine();

                string[] cmd_split = command.Split(' ');

                string instruction = cmd_split[0];

                switch (instruction)
                {
                    case "add":
                        string name = string.Join(" ", cmd_split.ToList().GetRange(1, cmd_split.Length - 1));

                        participants.Add(new SecretSantaParticipant(name, next_id));
                        next_id++;
                        break;
                    case "remove":
                        int removing_id = int.Parse(cmd_split[1]);

                        participants.RemoveAll(x => x.SantaID == removing_id);

                        break;
                    case "run-santa":
                        CalculateMatchings(participants);
                        break;
                    case "exit":
                        loop_running = false;
                        break;
                    case "edit":
                        int editing_id = int.Parse(cmd_split[1]);
                        string new_name = string.Join(" ", cmd_split.ToList().GetRange(2, cmd_split.Length - 2));
                        SecretSantaParticipant editing_participant = participants.Where(x => x.SantaID == editing_id).ToList()[0];
                        editing_participant.setName(new_name);
                        break;
                    case "list":
                        foreach(SecretSantaParticipant p in participants)
                        {
                            Console.WriteLine(p.getName());
                            Console.WriteLine(p.SantaID);
                            Console.WriteLine("");
                        }
                        break;
                    default:
                        Console.WriteLine("Unknown command: " + command);
                        break;


                }
            }
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
