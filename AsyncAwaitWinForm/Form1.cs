using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

/* Task is a lightweight object for managing a parallelizable unit of work. It can be used whenever you want to execute something in parallel. 
 * Parallel means the work is spread across multiple processors to maximize computational speed. Tasks are tuned for leveraging multicores processors. */
/* Task - helps in achieving the parallelizing the execution of unit of work along with Main thread's execution */
/* Threads - still executed sequentially but with equal amount CPU resource allocation so that it looks like parallel work completion, but actually not */
namespace AsyncAwaitWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int CountCharacter()
        {
            int Count = 0;
            using (StreamReader Sreader = new StreamReader("H:\\TestRead.docx"))
            {
                Count = Sreader.ReadToEnd().Length;
            }

            Thread.Sleep(15000); //Calling the method synchronously causes main thread to go unresponsive, cant move the dialog/ scroll down.
            return Count;
        }

        private async void Count_Click(object sender, EventArgs e) // To fix the below problem add async keyword to the method to be called asynchronously
        {
            
            // Task Class present in System.Threading.Tasks;
           // Task task1 = new Task(CountCharacter); // Without giving generic <int> type, showing the method has the wrong return type
            Task<int> task = new Task<int>(CountCharacter); //Task is a unit of work to do..., generally time running task we will offload to a Task class to free Main/Other Thread
            task.Start(); // Starts a Task 
            int Count = 0;
            //Count = CountCharacter();
            lblMessage.Text = "Processing File. Please wait..."; //Even this is not appearing due to main thread goes suspended when calling the CountCharacter method.!
            Count = await task;
            
            lblMessage.Text = "Total Characters in the file " + Count;
            //As far as my understanding, if we use Worker Thread classes we may need to create different worker threads for different tasks/methods which still need to be managed
            // for better CPU Resources..!
        }


    }
}
