namespace HumanTimeFormat
{

//-----------------------------------------------------------------------------
using System;
using System.Text;
public class HumanTimeFormat{
    public static string formatDuration(int seconds){
        if(seconds == 0) {return "now";}

        // INITIALIZATION
        int[] durations = new int[] {365,24,60,60,1};
        int len = durations.Length;
        for (int i = len-3; i >= 0; i--) {
            //Changes durations to be in terms of seconds.
            durations[i] *= durations[i+1];
        }
        string[] names = new string[] {"year","day","hour","minute","second"}; 

        // PROCESSING
        StringBuilder date = new StringBuilder();
        String addend;
        for(int i = 0; i < len; i++) {
            addend = dateAddend(durations[i],names[i]);
            if(!String.IsNullOrEmpty(addend)) {
                date.Append(addend+", ");
            }
        }
        date.Replace(", ","",date.Length-2,2);
        int idx;
        if((idx = date.ToString().LastIndexOf(", ")) != -1) {
            date.Replace(", "," and ", idx, 2);
        }
        return date.ToString();

        // STRING BUILDING
        String dateAddend(int duration, string name) {
            StringBuilder formattedDate = new StringBuilder();
            int timeUnit = seconds/duration;
            if(duration != 1) {seconds %= duration;}
                //Identity Clause: do not Mod if referring to self time-unit (seconds).
            if(timeUnit > 0) {
                formattedDate.AppendFormat("{0} {1}",timeUnit,name);
                if(timeUnit != 1) {
                    formattedDate.Append("s");
                }
            } 
            return formattedDate.ToString();
        }
    }
}
//-----------------------------------------------------------------------------
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(HumanTimeFormat.formatDuration(3661));
    }
}

}
