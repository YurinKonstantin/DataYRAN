using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace DataYRAN
{
    public sealed partial class BlankPageObrData
    {
        private async Task StartClientBD(string zapros, string ip)
        {
            try
            {
                // Create the StreamSocket and establish a connection to the echo server.
                using (var streamSocket = new Windows.Networking.Sockets.StreamSocket())
                {

                    // The server hostname that we will be establishing a connection to. In this example, the server and client are in the same process.
                    var hostName = new Windows.Networking.HostName(ip);

                    //  this.clientListBox.Items.Add("client is trying to connect...");
                    // MessageDialog messageDialog1 = new MessageDialog("client is trying to connect...");
                    //  await messageDialog1.ShowAsync();

                    await streamSocket.ConnectAsync(hostName, "8888");

                    //  this.clientListBox.Items.Add("client connected");
                    // messageDialog1 = new MessageDialog("client connected");
                    //  await messageDialog1.ShowAsync();
                    // Send a request to the echo server.
                    string request = "BDB!" + "\t" + zapros;
                  
                    using (Stream outputStream = streamSocket.OutputStream.AsStreamForWrite())
                    {
                        using (var streamWriter = new StreamWriter(outputStream))
                        {
                            await streamWriter.WriteLineAsync(request);
                            await streamWriter.FlushAsync();
                        }
                    }

                    // this.clientListBox.Items.Add(string.Format("client sent the request: \"{0}\"", request));
                    //     messageDialog1 = new MessageDialog("client sent the request: \"{0}\"", request);
                    //  await messageDialog1.ShowAsync();
                    // Read data from the echo server.
                    string response;
                    using (Stream inputStream = streamSocket.InputStream.AsStreamForRead())
                    {
                        using (StreamReader streamReader = new StreamReader(inputStream))
                        {
                            response = await streamReader.ReadToEndAsync();
                        }
                    }
                    if (response != String.Empty)
                    {

                        await ParserTabSob(response);
                        // ViewModel.SostoYs = vs[0];

                        // if (vs.Length > 1)
                        // {

                        // }
                        
                    }

                    else
                    {
                        MessageDialog messageDialog12 = new MessageDialog("Данные по запросу не обнаружены");
                        await messageDialog12.ShowAsync();
                    }




                }

                //   this.clientListBox.Items.Add("client closed its socket");
                //  MessageDialog messageDialog = new MessageDialog("client closed its socket");
                //  await messageDialog.ShowAsync();
            }
            catch (Exception ex)
            {

                MessageDialog messageDialog = new MessageDialog("Error" + ex.ToString());
                messageDialog.ShowAsync();
            }
        }
        public async Task addSobIzBD(string nameFile, string nemeBAAK, string time1, double[] Amp, double[] Nul, int[] coutN1, Double[] sig, string[] timeS)
        {
            string[] array = nameFile.Split('_');
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
       () =>
       {
           ViewModel.ClassSobs.Add(new ClassSob()
           {
               nameFile = nameFile,
               nameklaster = array[0],
               nameBAAK = nemeBAAK,
               time = time1,
               Amp0 = Convert.ToInt16(Amp[0]),
               Amp1 = Convert.ToInt16(Amp[1]),
               Amp2 = Convert.ToInt16(Amp[2]),
               Amp3 = Convert.ToInt16(Amp[3]),
               Amp4 = Convert.ToInt16(Amp[4]),
               Amp5 = Convert.ToInt16(Amp[5]),
               Amp6 = Convert.ToInt16(Amp[6]),
               Amp7 = Convert.ToInt16(Amp[7]),
               Amp8 = Convert.ToInt16(Amp[8]),
               Amp9 = Convert.ToInt16(Amp[9]),
               Amp10 = Convert.ToInt16(Amp[10]),
               Amp11 = Convert.ToInt16(Amp[11]),
               Nnut0 = Convert.ToInt16(coutN1[0]),
               Nnut1 = Convert.ToInt16(coutN1[1]),
               Nnut2 = Convert.ToInt16(coutN1[2]),
               Nnut3 = Convert.ToInt16(coutN1[3]),
               Nnut4 = Convert.ToInt16(coutN1[4]),
               Nnut5 = Convert.ToInt16(coutN1[5]),
               Nnut6 = Convert.ToInt16(coutN1[6]),
               Nnut7 = Convert.ToInt16(coutN1[7]),
               Nnut8 = Convert.ToInt16(coutN1[8]),
               Nnut9 = Convert.ToInt16(coutN1[9]),
               Nnut10 = Convert.ToInt16(coutN1[10]),
               Nnut11 = Convert.ToInt16(coutN1[11]),
               TimeS0 = timeS[0],
               TimeS1 = timeS[1],
               TimeS2 = timeS[2],
               TimeS3 = timeS[3],
               TimeS4 = timeS[4],
               TimeS5 = timeS[5],
               TimeS6 = timeS[6],
               TimeS7 = timeS[7],
               TimeS8 = timeS[8],
               TimeS9 = timeS[9],
               TimeS10 = timeS[10],
               TimeS11 = timeS[11],
               sig0 = sig[0],
               sig1 = sig[1],
               sig2 = sig[2],
               sig3 = sig[3],
               sig4 = sig[4],
               sig5 = sig[5],
               sig6 = sig[6],
               sig7 = sig[7],
               sig8 = sig[8],
               sig9 = sig[9],
               sig10 = sig[10],
               sig11 = sig[11],
               SumAmp = Convert.ToInt32(Amp.Sum()),
               SumNeu = coutN1.Sum(),
               Nnull0 = Convert.ToInt16(Nul[0]),
               Nnull1 = Convert.ToInt16(Nul[1]),
               Nnull2 = Convert.ToInt16(Nul[2]),
               Nnull3 = Convert.ToInt16(Nul[3]),
               Nnull4 = Convert.ToInt16(Nul[4]),
               Nnull5 = Convert.ToInt16(Nul[5]),
               Nnull6 = Convert.ToInt16(Nul[6]),
               Nnull7 = Convert.ToInt16(Nul[7]),
               Nnull8 = Convert.ToInt16(Nul[8]),
               Nnull9 = Convert.ToInt16(Nul[9]),
               Nnull10 = Convert.ToInt16(Nul[10]),
               Nnull11 = Convert.ToInt16(Nul[11])
           });

       });

        }
        public async Task ParserTabSob(string text)
        {
            double[] Amp = new double[12];
            double[] Nul = new double[12];
            int[] coutN1 = new int[12];
            double[] sig = new double[12];
            string time1 = null;
            string nameFile = null;
            string[] Nastroc = text.Split('\n');
            for (int i = 0; i < Nastroc.Length; i++)
            {
                if (Nastroc[i] != String.Empty)
                {
                    string[] stroc = Nastroc[i].Split('\t');
                    int x = 0;
                    for (int j = 5; j < 17; j++)
                    {
                        try
                        {


                            Amp[x] = Convert.ToDouble(stroc[j]);
                            x++;
                        }
                        catch(Exception ex)
                        {
                            MessageDialog messageDialog = new MessageDialog("1"+" "+j+" "+ stroc[j]);
                              await messageDialog.ShowAsync();
                        }

                    }
                    x = 0;
                    for (int j = 18; j < 30; j++)
                    {
                        coutN1[x] = Convert.ToInt32(stroc[j]);
                        x++;

                    }
                    x = 0;
                    for (int j = 31; j < 43; j++)
                    {
                        try { 
                        Nul[x] = Convert.ToDouble(stroc[j]);
                            x++;
                        }
                        catch (Exception ex)
                    {
                        MessageDialog messageDialog = new MessageDialog("2" + " " + j + " " + stroc[j]);
                            await messageDialog.ShowAsync();
                    }
                }
                    x = 0;
                    for (int j = 43; j < 54; j++)
                    {
                        try
                        {
                          string  text1 = stroc[j].Replace(".", ",");
                            sig[x] = Convert.ToDouble(text1);
                            x++;
                        }
                        catch (Exception ex)
                        {
                            MessageDialog messageDialog = new MessageDialog("3" + " " + j + " " + stroc[j]);
                            await messageDialog.ShowAsync();
                        }

                    }
                    string[] timeS = new string[12];
                    await addSobIzBD(stroc[2], stroc[3], stroc[1], Amp, Nul, coutN1, sig, timeS);
                }

            }


        }
    }
}
