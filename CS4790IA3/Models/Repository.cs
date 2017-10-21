using System.Collections.Generic;


namespace CS4790IA3.Models
{
    public class Repository
    {
 /*       public static RegistrationRunners getCourseAndSections(int? id)
        {
            RegistrationRunners reg = FunRun.getCourseAndSections(id);
            return courseSection;
        } */

        public static List<Registration> getRegistrations()
        {
            return FunRun.getRegistrations();
        }


        public static void createRegistration(Registration registration)
        {
            FunRun.createRegistration(registration);
        }



   /*     public static List<Runner> getRunners(int registrationID)
        {
            return FunRun.getRunners(registrationID);
        } */


        public static void createRunner(Runner runner)
        {
            FunRun.createRunner(runner);
        }

    }

    public class RegistrationRunners
    {
        public RegistrationRunners()
        {
            runners = new List<Runner>();
            for (int i = 0; i < 11; i++)
            {
                Runner runner = new Runner();
                runner = null;
                runners.Add(runner);
            }
        }

        public Registration registration { get; set; }
        public List<Runner> runners { get; set; }
    }

}