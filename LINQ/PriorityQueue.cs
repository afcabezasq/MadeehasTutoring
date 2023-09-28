using System.Collections.Generic;
public class ExamplePriorityQueue{
    public PriorityQueue<string,int> pr{get;set;}


    public void testPriorityQueu(){
        pr =  new PriorityQueue<string, int>();
        pr.Enqueue("Medical Appointment", -1); //lowest priority
        pr.Enqueue("Concert",-10);
        pr.Enqueue("Paperwork Residence",-6);

        while(pr.Count > 0){
            Console.WriteLine(pr.Dequeue());
        }
    }

}