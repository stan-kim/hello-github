using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using SATOPrinterAPI;
// SerialPort 클래스.
//using System.IO.Ports;

// Queue.
using System.Collections.Concurrent;


namespace QRCodePrint
{
    public partial class Form1 : Form
    {
        static Form1 clsFormMain;

        Printer SATOPrinter = null;
        Driver SATODriver = null;

        Printer SATOPrinter2 = null;
        Driver SATODriver2 = null;

        string sBaseDate = "00000000";
        string sNowDate;
        string[] Design_Data = new string[5];

        bool Minimized = false;
        // PopupMSG errPopUp;
        bool bTCPConnected = false;

        bool bTCPConnected_1 = false;
        bool bTCPConnected_2 = false;

        bool bSerialConnected = false;
        bool bUIColorDisplay = false;

        bool bPGM_Loading = false;

        string sPrintQR;

        TcpClient tcClient;
        NetworkStream stream;

        public static Thread g_SerialThread;

        int iYield_Total;
        int iYield_Pass;
        int iYield_Fail;

        int[] iPLCReadData = new int[16];
        int iSerialReadFail_Count = 0;
        bool bLogSaveFlag = false;

        System.Windows.Forms.DataVisualization.Charting.Chart CHART_YIELD = new System.Windows.Forms.DataVisualization.Charting.Chart();

        int Count_Val = 1;
        int Count_Val2 = 1;
        int bSingle_Lot_Mode = 0;


        //#########################################################################################
        //##
        //## MCU 통신용.(PC <- MCU).
        //##
        //###########################
        public Thread MCUThread = null;

		// Thread 동작 플래그.(공용).
		public volatile bool bRunMCUThread = true;

		// 시리얼 데이터 수신용 ConcurrentQueue.
		ConcurrentQueue<byte[]> clsMCUQueue = null;
		public int GnDataIndex = 0;
		public byte[] GbyRecvData = new byte[516];
        //#########################################################################################

        public Form1()
        {
            InitializeComponent();

            SATOPrinter = new Printer();
            SATODriver = new Driver();

            SATOPrinter2 = new Printer();
            SATODriver2 = new Driver();

            cbInterfaces.SelectedIndex = 0;
            cbInterfaces2.SelectedIndex = 0;

            bTCPConnected_1 = true;
            bTCPConnected_2 = true;


        }
        public delegate void QR_Print_Delegate(int Stage);

        public void QR_Print(int Stage)
        {
            if (Stage == 0)
            {
                if (textPartNum.Text.Length != 11)
                {
                    MessageBox.Show("Stage1 Lot를 확인하세요(11자리)");
                    return;
                }
                if (textCount.Text.Length != 4)
                {
                    MessageBox.Show("Stage1 Count를 확인하세요(4자리)");
                    return;
                }
            }
            else
            {
                if (textPartNum2.Text.Length != 11)
                {
                    MessageBox.Show("Stage2 Lot를 확인하세요(11자리)");
                    return;
                }
                if (textCount2.Text.Length != 4)
                {
                    MessageBox.Show("Stage2 Count를 확인하세요(4자리)");
                    return;
                }
            }

            DATE_Load();
            sNowDate = DateTime.Now.ToString("yyyyMMdd");

            if (Convert.ToInt64(sBaseDate) < Convert.ToInt64(sNowDate))
            {
                sBaseDate = sNowDate;
                DATE_Save();

                Count_Val = 1;
                textCount.Text = "0001";
                Count_Val2 = 1;
                textCount2.Text = "0001";
                Task_Save();
            }

            MouseWait = true;
            try
            {
                string st1, st2, st3, st4, st5, st6, st7, st8, st9, st10, st11;

               // st1 = "[STX][ESC]A[ESC]A3V+00000H+0000[ESC]CS6[ESC]#F5[ESC]A1V00256H0200[ESC]Z[ETX][STX][ESC]A[ESC]PS[ESC]WK12345[ESC]%2[ESC]H0164[ESC]V00227[ESC]2D30,L,05,1,0[ESC]DN0026,";

                st1 = Design_Data[0];

                if (Stage == 0)
                {
                    st2 = textPartNum.Text;
                }
                else
                {
                    st2 = textPartNum2.Text;
                }

                //st3 = "[CR][LF]";
                st3 = Design_Data[1];

                st4 = DateTime.Now.ToString("yyyyMMdd ");
                if (bSingle_Lot_Mode == 1)
                {
                    Count_Val = Convert.ToInt32(textCount.Text);
                    Count_Val2 = Count_Val;

                    textCount.Text = String.Format("{0:D04}", Count_Val);
                    textCount2.Text = String.Format("{0:D04}", Count_Val2);
                    st5 = textCount.Text;
                }
                else
                {
                    if (Stage == 0)
                    {
                        Count_Val = Convert.ToInt32(textCount.Text);
                        textCount.Text = String.Format("{0:D04}", Count_Val);
                        st5 = textCount.Text;
                    }
                    else
                    {
                        Count_Val2 = Convert.ToInt32(textCount2.Text);
                        textCount2.Text = String.Format("{0:D04}", Count_Val2);
                        st5 = textCount2.Text;
                    }
                }
               // st6 = "[ESC]%2[ESC]H0164[ESC]V00084[ESC]P02[ESC]RH0,SATO0.ttf,0,020,020,";
                st6 = Design_Data[2];
                if (Stage == 0)
                {
                    st7 = textPartNum.Text;
                }
                else
                {
                    st7 = textPartNum2.Text;
                }
                //st8 = "[ESC]%2[ESC]H0164[ESC]V00063[ESC]P02[ESC]RH0,SATO0.ttf,0,020,020,";
                st8 = Design_Data[3];

                st9 = DateTime.Now.ToString("yyyyMMdd ");
                if (bSingle_Lot_Mode == 1)
                {
                    Count_Val = Convert.ToInt32(textCount.Text);
                    Count_Val2 = Count_Val;

                    textCount.Text = String.Format("{0:D04}", Count_Val);
                    textCount2.Text = String.Format("{0:D04}", Count_Val2);
                    st10 = textCount.Text;
                }
                else
                {
                    if (Stage == 0)
                    {
                        Count_Val = Convert.ToInt32(textCount.Text);
                        textCount.Text = String.Format("{0:D04}", Count_Val);
                        st10 = textCount.Text;
                    }
                    else
                    {
                        Count_Val2 = Convert.ToInt32(textCount2.Text);
                        textCount2.Text = String.Format("{0:D04}", Count_Val2);
                        st10 = textCount2.Text;
                    }
                }
                //st11 = "[ESC]%2[ESC]H0164[ESC]V00042[ESC]P02[ESC]RH0,SATO0.ttf,0,020,020,Result : OK[ESC]Q1[ESC]Z[ETX]";
                st11 = Design_Data[4];

                txtSend.Text = st1 + st2 + st3 + st4 + st5 + st6 + st7 + st8 + st9 + st10 + st11;

                byte[] cmddata = Utils.StringToByteArray(ControlCharReplace(txtSend.Text));

                if (Stage == 0)
                {
                    SetInterface();
                    SATOPrinter.Send(cmddata);
                    bTCPConnected_1 = true;
                    func_AddLog("Print STG 1 : " + st7 + " " + st9 + " " + st10);

                    Count_Val = Convert.ToInt32(textCount.Text);
                    Count_Val++;

                    textCount.Text = String.Format("{0:D04}", Count_Val);

                    if (bSingle_Lot_Mode == 1)
                    {
                        Count_Val2 = Count_Val;
                        textCount2.Text = String.Format("{0:D04}", Count_Val2);
                    }
                }
                else
                {
                    SetInterface2();
                    SATOPrinter2.Send(cmddata);
                    bTCPConnected_2 = true;

                    func_AddLog("Print STG 2 : " + st7 + " " + st9 + " " + st10);

                    if (bSingle_Lot_Mode == 1)
                    {
                        Count_Val = Convert.ToInt32(textCount.Text);
                        Count_Val++;
                        textCount.Text = String.Format("{0:D04}", Count_Val);
                        Count_Val2 = Count_Val;
                        textCount2.Text = String.Format("{0:D04}", Count_Val2);
                    }
                    else
                    {
                        Count_Val2 = Convert.ToInt32(textCount2.Text);
                        Count_Val2++;
                        textCount2.Text = String.Format("{0:D04}", Count_Val2);
                    }

                }
                Task_Save();
            }
            catch (Exception ex)
            {
                if (Stage == 0)
                {
                    bTCPConnected_1 = false;
                }
                else
                {
                    bTCPConnected_2 = false;
                }

                MessageBox.Show("QR_Print Error :" + ex.Message);

            }

            MouseWait = false;

        }


        private void InitVariable()
        {
            try
            {
                // Main Form.
                clsFormMain = this;

                // I/O 데이터 수신용 ConcurrentQueue 생성.
                clsMCUQueue = new ConcurrentQueue<byte[]>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("InitVariable Exception\r\n" + ex.Message);
            }
        }

        public void ThreadMCU(object obj)
        {
            // 부모 클래스.
            Form1 cFormMain = (Form1)obj;

            byte[] byBuff = new byte[1024];
            int nIndex, nLength;

            // Data.
            byte[] byTmp = new byte[64];

            // 데이터 시작.
            bool bReadStart = false;

            // 데이터 처리.
           // float fValue = 0.0f;

            string strTmp;

            // 스레드 루틴.
            while (true)
            {
                Thread.Sleep(100);

                if (!cFormMain.bRunMCUThread)             
                {
                    break;
                }
                else
                {
                    try
                    {
                        if (ComMCU.IsOpen && !clsMCUQueue.IsEmpty)
                        {
                            // Queue 데이터 읽기.
                            bool isSuccessful = clsMCUQueue.TryDequeue(out byBuff);
                            if (isSuccessful)
                            {
                                nIndex = 0;
                                nLength = byBuff.Length;

                                //##
                                //## 데이터 분석.(포맷:$P압력,온도#).
                                //## 예:
                                while (cFormMain.bRunMCUThread && (nLength > 0))
                                {
                                    switch (byBuff[nIndex])
                                    {
                                        //#############################################################
                                        //##
                                        //## 시작 문자.('#').
                                        //##
                                        //#############################################################
                                        case 0x23:
                                            //clsFormMain.QR_Print(0);

                                            GnDataIndex = 0;

                                            // 데이터 시작.
                                            bReadStart = true;

                                            // 배열 초기화.(2016.07.14).
                                            Array.Clear(GbyRecvData, 0, GbyRecvData.Length);
                                            break;

                                        //#############################################################
                                        //##
                                        //## 종료 문자.('$').
                                        //##
                                        //#############################################################
                                        case 0x24:
                                            if (!bReadStart) break;

                                            // 데이터 끝부분.
                                            GbyRecvData[GnDataIndex] = 0x00;

                                            // 데이터 길이 체크.
                                            if (GnDataIndex != 2) break;

                                            // 데이터 분석.
                                            Array.Copy(GbyRecvData, 0, byTmp, 0, GnDataIndex);
                                            strTmp = ByteArrayExt.ByteToString(byTmp);

                                            // 구분자(',')로 문자열 구분.
                                            string[] strValues = strTmp.Split(',');

                                            // 데이터 분석.
                                            switch (GbyRecvData[0])
                                            {
                                                //#####################################################
                                                //##
                                                //## 결과 .('W').
                                                //##
                                                //#####################################################
                                                case 0x57:

                                                    switch (GbyRecvData[1])
                                                    {
                                                        case 0x31:
                                                          //  Invoke(new QR_Print_Delegate(QR_Print), 0);
                                                            QR_Print(0);
                                                            break;
                                                        case 0x32:
                                                            // Invoke(new QR_Print2_Delegate(QR_Print2), 1);
                                                            //Invoke(new QR_Print_Delegate(QR_Print), 1);
                                                            QR_Print(1);
                                                            break;
                                                        default:
                                                            Invoke(new func_AddLog_Delegate(func_AddLog), "Result Format Fail.");
                                                           // func_AddLog("Result Format Fail.");
                                                            break;
                                                    }
                                                    break;
                                                    

                                                //#####################################################
                                                //##
                                                //## 기타.
                                                //##
                                                //#####################################################
                                                default:
                                                    break;
                                            }

                                            // 데이터 끝.
                                            bReadStart = false;
                                            break;

                                        //#############################################################
                                        //##
                                        //## 기타 문자.
                                        //##
                                        //#############################################################
                                        default:
                                            GbyRecvData[GnDataIndex] = byBuff[nIndex];
                                            GnDataIndex++;
                                            break;
                                    }

                                    // 인덱스 증가 및 데이터 감소.
                                    nIndex++;
                                    nLength--;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }

                }
            }

           // Debug.WriteLine("ThreadMCU Close.");
        }
        //##
        //## MCU 시리얼통신 데이터 수신.
        //##
        private void ComMCU_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            this.Invoke(new EventHandler(ReadMCU));
        }

        // RS232 시리얼통신 데이터 수신.
        private void ReadMCU(object s, EventArgs e)
        {
            int nReadBytes;

            byte[] byTmpBuff = new byte[2048];
            byte[] byRecvData;

            //##
            //## 주의.(2016.04.08).
            //##
            //## 시리얼 포트 Read() 함수는 ReadTimeout 속성, 즉 읽기 작업을 마쳐야 하는
            //## 제한 시간(밀리초)을 기본값인 InfiniteTimeout(-1) 로 설정되어있습니다.
            //## 그래서 이 값을 적절한 값으로 설정해주고 아래와 같이 해줘야 데이터가
            //## 수신되지않아도 블로킹이 되지않습니다.
            //## 
            try
            {
                // 데이터 읽기.
                nReadBytes = (ComMCU.BytesToRead > 0) ? ComMCU.Read(byTmpBuff, 0, byTmpBuff.Length) : 0;

                // 수신 데이터가 있을 경우, 읽어옴.
                if (nReadBytes > 0)
                {
                    // 받은 바이트 수 만큼 배열을 선언하고 복사.
                    byRecvData = new byte[nReadBytes];
                    Array.Copy(byTmpBuff, 0, byRecvData, 0, nReadBytes);

                    // 데이터를 큐에 저장.(2016.07.14).
                    clsMCUQueue.Enqueue(byRecvData);

                    // 아주 중요함.(2020.11.18).
                    Thread.Sleep(3);

                    // Debug.
                    string message = new UTF8Encoding().GetString(byTmpBuff, 0, nReadBytes);
                    //WriteLog("R: " + message);
                    func_AddLog("R: " + message);
                    /*///*/
                }
            }
            catch (Exception ex)
            {
                nReadBytes = 0;
                MessageBox.Show(ex.Message);
            }
        }
       

        void PieChartDraw()
        {

            CHART_YIELD.Series[0].Points.Clear();                  // 차트를 클리어함

            CHART_YIELD.Series[0].Points.AddXY("PASS", iYield_Pass);        // 차트에 벨류값을 넣어줌
            CHART_YIELD.Series[0].Points.AddXY("FAIL", iYield_Fail);        // 차트에 벨류값을 넣어줌
            CHART_YIELD.Invalidate();                              // 차트를 업데이트 함

          
        }

        //##
        //## 비트 연산 클래스.(2016.07.11).
        //## </summary>
        public static class ByteArrayExt
        {
            public static byte[] SetBit(byte[] self, int index, bool value)
            {
                int byteIndex = index / 8;
                int bitIndex = index % 8;
                byte mask = (byte)(1 << bitIndex);

                self[byteIndex] = (byte)(value ? (self[byteIndex] | mask) : (self[byteIndex] & ~mask));
                return self;
            }

            public static byte[] ToggleBit(byte[] self, int index)
            {
                int byteIndex = index / 8;
                int bitIndex = index % 8;
                byte mask = (byte)(1 << bitIndex);

                self[byteIndex] ^= mask;
                return self;
            }

            public static bool GetByteBit(byte[] self, int index)
            {
                int byteIndex = index / 8;
                int bitIndex = index % 8;
                byte mask = (byte)(1 << bitIndex);

                return (self[byteIndex] & mask) != 0;
            }

            public static bool GetBit(byte self, int index)
            {
                byte mask = (byte)(1 << index);

                return (self & mask) != 0;
            }

            // Convert bool array to byte array.
            public static byte[] ToByteArray(bool[] input)
            {
                if (input.Length % 8 != 0)
                {
                    throw new ArgumentException("input");
                }
                byte[] ret = new byte[input.Length / 8];
                for (int i = 0; i < input.Length; i += 8)
                {
                    int value = 0;
                    for (int j = 0; j < 8; j++)
                    {
                        if (input[i + j])
                        {
                            value += 1 << (7 - j);
                        }
                    }
                    ret[i / 8] = (byte)value;
                }
                return ret;
            }

            // 프로그램 입력 - 단위 인덱스.
            public static byte GetUnitInfo(string strUnit)
            {
                byte byHex = 0x00;

                switch (strUnit)
                {
                    case "o": byHex = 0x01; break;
                    case "Ko": byHex = 0x02; break;
                    case "Mo": byHex = 0x03; break;
                    case "pF": byHex = 0x04; break;
                    case "nF": byHex = 0x05; break;
                    case "uF": byHex = 0x06; break;
                    case "uH": byHex = 0x07; break;
                    case "mH": byHex = 0x08; break;
                    case "H": byHex = 0x09; break;
                    case "㎷": byHex = 0x0A; break;
                    case "V": byHex = 0x0B; break;
                }

                return byHex;
            }

            // 프로그램 입력 - 단위 문자열.
            public static string GetUnitInfo(byte byUnit)
            {
                string strUnit = "";

                switch (byUnit)
                {
                    case 0x01: strUnit = "o"; break;
                    case 0x02: strUnit = "Ko"; break;
                    case 0x03: strUnit = "Mo"; break;
                    case 0x04: strUnit = "pF"; break;
                    case 0x05: strUnit = "nF"; break;
                    case 0x06: strUnit = "uF"; break;
                    case 0x07: strUnit = "uH"; break;
                    case 0x08: strUnit = "mH"; break;
                    case 0x09: strUnit = "H"; break;
                    case 0x0A: strUnit = "㎷"; break;
                    case 0x0B: strUnit = "V"; break;
                }

                return strUnit;
            }

            // 정수를 ASCII 바이트 배열로 변환하는 함수.(2016.10.06).
            public static int IntToByteArray(int nValue, ref byte[] byValue, int nSize)
            {
                byte[] byTmp = new byte[16];

                for (int i = 0; i < byValue.Length; i++) byValue[i] = 0x30;

                byTmp = Encoding.ASCII.GetBytes(nValue.ToString());
                System.Buffer.BlockCopy(byTmp, 0, byValue, nSize - byTmp.Length, byTmp.Length);

                return byTmp.Length;
            }

            public static int IntToTwoBytes(int nValue, ref byte[] byValue, int nSize)
            {
                byte[] byTmp = new byte[4];

                byTmp = BitConverter.GetBytes(nValue);

                // 상위 비트를 ASCII 문자변환.
                byValue[0] = (byte)((byTmp[0] & 0xF0) >> 4);
                if (byValue[0] >= 0x00 && byValue[0] <= 0x09)
                {
                    byValue[0] += 0x30;
                }
                else
                {
                    byValue[0] += 0x37;
                }

                // 하위 비트를 ASCII 문자변환.
                byValue[1] = (byte)(byTmp[0] & 0x0F);
                if (byValue[1] >= 0x00 && byValue[1] <= 0x09)
                {
                    byValue[1] += 0x30;
                }
                else
                {
                    byValue[1] += 0x37;
                }

                return 0;
            }

            // ASCII 바이트 배열을 정수로 변환하는 함수.(2016.10.06).
            public static int ByteArrayToInt(byte[] bytes, int start, int length)
            {
                int Temp = 0;
                int Result = 0;
                int i, j = 1;

                for (i = start + length - 1; i >= start; i--)
                {
                    Temp = ((int)bytes[i]) - 48;
                    if (Temp < 0) continue;

                    if (Temp < 0 || Temp > 9)
                    {
                        throw new Exception("Bytes In AsciiBytesToInt Are Not An Int");
                    }

                    Result += Temp * j;
                    j *= 10;
                }

                return Result;
            }

            // 바이트 배열을 String으로 변환.
            public static string ByteToString(byte[] strByte)
            {
                string str = Encoding.ASCII.GetString(strByte);
                return str;
            }

            // String을 바이트 배열로 변환.
            public static byte[] StringToByte(string str)
            {
                byte[] strByte = Encoding.ASCII.GetBytes(str);
                return strByte;
            }
        }



        // 장치 초기화.
        private void InitDevice()
        {
            // 변수 초기화.
            InitVariable();

            //int nErrorCode;

            try
            {
                
                //##
                //## MCU 통신포트(RS232).
                //##
                if (ComMCU.IsOpen)
                {
                    ComMCU.Close();
                }

                // 기타 설정값은 디폴트.
                ComMCU.PortName = "COM2";
                ComMCU.Open();

                //##
                //## 주의.(2020.11.24).
                //##
                //## 수신 데이터가 계속들어오는 경우는, 아래와 같이
                //## 수신 버퍼를 지워줘야 됩니다. 그렇지않으면 이전에 수신 버퍼에
                //## 일부분만 들어온 데이터때문에 데이터 처리시 오류가 발생할 수 있습니다.
                //##
                ComMCU.DiscardInBuffer();
                ComMCU.DiscardOutBuffer();

                // 연결 성공.
                if (ComMCU.IsOpen)
                {
                    func_AddLog("[ComMCU Connected]");
                    // MCU 통신 스레드.
                    MCUThread = new Thread(new ParameterizedThreadStart(ThreadMCU));
                    MCUThread.Start(this);
                    bSerialConnected = true;
                }
                else
                {
                    func_AddLog("[ComMCU Disconnected.!!]");
                    bSerialConnected = false;
                }
                /*///*/
            }
            catch (Exception ex)
            {
                MessageBox.Show("InitDevice Exception: " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            func_AddLog("===========Program Loading==========");
            tmDisplay.Enabled = true;
            tmUI_Update.Enabled = true;
            tm_PLC.Enabled = true;
            g_SerialThread = new Thread(func_SerialTrhead);

            Task_Load();
            DATE_Load();
            Design_Load();
            sNowDate = DateTime.Now.ToString("yyyyMMdd");

            if (Convert.ToInt64(sBaseDate) < Convert.ToInt64(sNowDate))
            {
                sBaseDate = sNowDate;
                DATE_Save();

                Count_Val = 1;
                textCount.Text = "0001";
                Count_Val2 = 1;
                textCount2.Text = "0001";
                Task_Save();
            }
            //Port_Load();
            //func_TCP_Connect();
            // SerialPort_Connect();
            // CHART_YIELD = CHT_YIELD_RING_TOTAL;

            // 변수 초기화.
            // InitVariable();

            // PieChartDraw();
            //  DataGridInit();
            g_SerialThread.Start();
            InitDevice();

            if (bSingle_Lot_Mode == 1)
            {
                cSingleLot.Checked = true;
            }

        }
        public void func_SerialTrhead()
        {
            while (true)
            {
                Thread.Sleep(500);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            func_AddLog("===========Program Close==========");
            try
            {
                stream.Close();
            }
            catch(Exception)
            {

            }
            try
            {
                tcClient.Close();
            }
            catch (Exception)
            {

            }

            bSerialConnected = false;
            if (SP_PLC.IsOpen == true)
                SP_PLC.Close();
            g_SerialThread.Abort();

            if (ComMCU.IsOpen)
            {
                ComMCU.Close();
                MCUThread.Abort();
            }
            

        }
        private void func_TCP_Connect()
        {
            func_AddLog("IP :" + tB_IP.Text + ",PORT:" + tB_IP_PORT.Text + " Connect Try");
            string address = tB_IP.Text;
            int port = Convert.ToInt32(tB_IP_PORT.Text);
            try
            {
                tcClient = new TcpClient(address, port);
                stream = tcClient.GetStream();
                bTCPConnected = true;
                func_AddLog("TCP/IP Connect OK");
                //errPopUp.Hide();
            }
            catch
            {
                bTCPConnected = false;
                func_AddLog("TCP/IP Connect FAIL");
               
            }
        }
        private void BTN_PORTOPEN_Click(object sender, EventArgs e)
        {

            //try
            //{
            //    string msg = " ^XA^JUS^LRN^CI27^PA0,1,1,0^MMT^PW240^LL120^LS0 ^FT79,112^BQN,2,4^FH^FDLA,";
            //      msg += DateTime.Now.Year.ToString("D4") + DateTime.Now.Month.ToString("D2")+ DateTime.Now.Day.ToString("D2")+ tB_MANUAL_LOT.Text;
            //      msg += "^FS^XZ";
            //    byte[] buff = Encoding.ASCII.GetBytes(msg);
            //    stream.Write(buff, 0, buff.Length);
            //    //func_DisplayQR();
            //}
            //catch (Exception)
            //{
            //    func_AddLog("QR CODE Print FAIL");
            //}
            Print_QRCode(true);
            //Task_Save();
        }
       
        private void Print_QRCode(bool bManual)
        {
            try
            {
                //string msg = " ^XA^JUS^LRN^CI27^PA0,1,1,0^MMT^PW240^LL120^LS0 ^FT79,112^BQN,2,4^FH^FDLA,";
                //if (bManual == true)
                //    msg += DateTime.Now.Year.ToString("D4") + DateTime.Now.Month.ToString("D2") + DateTime.Now.Day.ToString("D2") + "-" + tB_MANUAL_LOT.Text;
                //else
                //{
                //    msg += DateTime.Now.Year.ToString("D4") + DateTime.Now.Month.ToString("D2") + DateTime.Now.Day.ToString("D2") + "-" + Convert.ToString(iYield_Pass);
                //    sPrintQR = DateTime.Now.Year.ToString("D4") + DateTime.Now.Month.ToString("D2") + DateTime.Now.Day.ToString("D2") + "-" + Convert.ToString(iYield_Pass);
                //}

                //msg += "^FS^XZ";
                //byte[] buff = Encoding.ASCII.GetBytes(msg);
                //stream.Write(buff, 0, buff.Length);
                ////func_DisplayQR();
            }
            catch (Exception)
            {
                //errPopUp.error_MSG_Display("QR PRINT DisConnected !!");
                // errPopUp.Show();
                bTCPConnected = false;
                func_AddLog("QR CODE Print FAIL");
            }
        }
        private void tmDisplay_Tick(object sender, EventArgs e)
        {
            TIME_date.Text = DateTime.Now.Year.ToString("D2") + " / " + DateTime.Now.Month.ToString("D2") + " / " + DateTime.Now.Day.ToString("D2") + "\n" + DateTime.Now.Hour.ToString("D2") + " : " + DateTime.Now.Minute.ToString("D2") + " : " + DateTime.Now.Second.ToString("D2") ;
        }

      
        private void SerialPort_Connect()
        {
            func_AddLog("Serial :" + tB_SERIAL_PORT.Text + " Connect Try");
            func_AddLog("BaudRate :" + tB_BAUDRATE.Text);
            if (SP_PLC.IsOpen == true)
                SP_PLC.Close();
            SP_PLC.PortName = tB_SERIAL_PORT.Text;
            SP_PLC.BaudRate = Convert.ToInt32(tB_BAUDRATE.Text);
            try
            {
                SP_PLC.Open();
                bSerialConnected = true;
                //errPopUp.Hide();

            }
            catch (Exception)
            {
                func_AddLog("SERIAL PORT OPEN FAIL");
                bSerialConnected = false;
            }
        }
        private void btn_SERIAL_CONNECT_Click(object sender, EventArgs e)
        {
            SerialPort_Connect();
            Port_Save();
        }

        private void btn_TCP_CONNECT_Click(object sender, EventArgs e)
        {
            //func_TCP_Connect();
           // Port_Save();
        }

        public delegate void func_AddLog_Delegate(String sLog);
        private void func_AddLog(String sLog)
        {
            String stmp;
            stmp = "[" + DateTime.Now.Hour.ToString("D2") + ":" + DateTime.Now.Minute.ToString("D2") + ":" + DateTime.Now.Second.ToString("D2") + ":" + DateTime.Now.Millisecond.ToString("D3")+ "]";
            try
            {
                LB_LOG.Items.Add(stmp + sLog);
            }
            catch(Exception)
            {
                TextLogSave("Log Display Exception");
            }
            TextLogSave(stmp + sLog);
        }

        private void tmUI_Update_Tick(object sender, EventArgs e)
        {
            
            if (bUIColorDisplay == false)
            {
                if (bTCPConnected_1 & bTCPConnected_2)
                {
                    lb_CON_PRINT.BackColor = System.Drawing.Color.Blue;
                    lb_CON_PRINT.ForeColor = System.Drawing.Color.White;
                    lb_CON_PRINT.Text = "Connected";

                }
                else
                {
                    lb_CON_PRINT.BackColor = System.Drawing.Color.Red;
                    lb_CON_PRINT.ForeColor = System.Drawing.Color.White;
                    lb_CON_PRINT.Text = "DisConnected";
                }


                if (bSerialConnected)
                {
                    lb_CON_SERIAL.BackColor = System.Drawing.Color.Blue;
                    lb_CON_SERIAL.ForeColor = System.Drawing.Color.White;
                    lb_CON_SERIAL.Text = "Connected";
                }
                else
                {
                    lb_CON_SERIAL.BackColor = System.Drawing.Color.Red;
                    lb_CON_SERIAL.ForeColor = System.Drawing.Color.White;
                    lb_CON_SERIAL.Text = "DisConnected";
                }
                bUIColorDisplay = true;
            }
            else
            {
                if (bTCPConnected_1 & bTCPConnected_2)
                {
                    lb_CON_PRINT.BackColor = System.Drawing.Color.Blue;
                    lb_CON_PRINT.ForeColor = System.Drawing.Color.White;
                    lb_CON_PRINT.Text = "Connected";
                }
                else
                {
                    lb_CON_PRINT.BackColor = System.Drawing.Color.White;
                    lb_CON_PRINT.ForeColor = System.Drawing.Color.Red;
                    lb_CON_PRINT.Text = "DisConnected";
                }
                if (bSerialConnected)
                {
                    lb_CON_SERIAL.BackColor = System.Drawing.Color.Blue;
                    lb_CON_SERIAL.ForeColor = System.Drawing.Color.White;
                    lb_CON_SERIAL.Text = "Connected";
                }
                else
                {
                    lb_CON_SERIAL.BackColor = System.Drawing.Color.White;
                    lb_CON_SERIAL.ForeColor = System.Drawing.Color.Red;
                    lb_CON_SERIAL.Text = "DisConnected";
                }
                bUIColorDisplay = false;
            }
       
        }


        public void TextLogSave(String sLog)
        {
            string SavePath = AppDomain.CurrentDomain.BaseDirectory;

            string Savedir = SavePath + @"\Log" + @"\TextLog";

            DirectoryInfo di = new DirectoryInfo(Savedir);                  // 저장할 폴더의 정보를 반환받음
            if (di.Exists == false)                                         // 저장할 폴더가 존재하지 않으면
            {
                di.Create();                                                // 저장할 폴더 생성
            }
            string FileName = string.Format("Log\\TextLog\\{0}_{1}_{2}_TextLog.txt", DateTime.Now.Year.ToString("D2"), DateTime.Now.Month.ToString("D2"), DateTime.Now.Day.ToString("D2"));
            StreamWriter sw = new StreamWriter(SavePath + FileName, true);
            sw.WriteLine(sLog);
            sw.Close();
        }
        public void Task_Save()
        {
           
            string SavePath = AppDomain.CurrentDomain.BaseDirectory;        // 현재 프로세서가 실행되고 있는 디렉토리 위치

            string Savedir = SavePath + @"\Data";                          // 저장할 위치 폴더의 스트링 값(프로세서가 실행되는 위치+저장 폴더 위치)

            DirectoryInfo di = new DirectoryInfo(Savedir);                  // 저장할 폴더의 정보를 반환받음
            if (di.Exists == false)                                         // 저장할 폴더가 존재하지 않으면
            {
                di.Create();                                                // 저장할 폴더 생성
            }
            string FileName = string.Format("Data\\Task.ini");     // 저장 폴더 + 파일명을 스트링으로 저장(카드번호, 축 번호)

            StreamWriter sw = new StreamWriter(SavePath + FileName);                                // 파을을 저장하기 위해 파일 스트림 생성 ( 프로세서 생성 위치 + (저장폴더+파일명))
                                                                                                    //sw.WriteLine("{0},{1},{2}", Convert.ToString(iYield_Total), textCount.Text, textCount2.Text);

            if (cSingleLot.Checked)
            {
                bSingle_Lot_Mode = 1;
                Count_Val2 = Count_Val;
                textCount2.Text = textCount.Text;
                textPartNum2.Text = textPartNum.Text;
            }
            else
            {
                bSingle_Lot_Mode = 0;
                if (textPartNum.Text == textPartNum2.Text)
                {
                    Count_Val2 = 1;
                    textCount2.Text = "0001";
                    textPartNum2.Text = "";
                }

            }
            sw.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8}", Convert.ToString(bSingle_Lot_Mode), textPartNum.Text, textPartNum2.Text, textCount.Text, textCount2.Text, textIP_1.Text, textIP_2.Text, textPort_1.Text, textPort_2.Text);
            sw.Close();
        }
        public void Port_Save()
        {
            string SavePath = AppDomain.CurrentDomain.BaseDirectory;        // 현재 프로세서가 실행되고 있는 디렉토리 위치

            string Savedir = SavePath + @"\Data";                          // 저장할 위치 폴더의 스트링 값(프로세서가 실행되는 위치+저장 폴더 위치)

            DirectoryInfo di = new DirectoryInfo(Savedir);                  // 저장할 폴더의 정보를 반환받음
            if (di.Exists == false)                                         // 저장할 폴더가 존재하지 않으면
            {
                di.Create();                                                // 저장할 폴더 생성
            }
            string FileName = string.Format("Data\\Port.ini");     // 저장 폴더 + 파일명을 스트링으로 저장(카드번호, 축 번호)

            StreamWriter sw = new StreamWriter(SavePath + FileName);                                // 파을을 저장하기 위해 파일 스트림 생성 ( 프로세서 생성 위치 + (저장폴더+파일명))
            //sw.WriteLine("{0},{1},{2},{3}", tB_IP.Text, tB_IP_PORT.Text, tB_SERIAL_PORT.Text, tB_BAUDRATE.Text);

            if (cSingleLot.Checked)
            {
                bSingle_Lot_Mode = 1;
                Count_Val2 = Count_Val;
                textCount2.Text = textCount.Text;
                textPartNum2.Text = textPartNum.Text;
            }
            else
            {
                bSingle_Lot_Mode = 0;
                if (textPartNum.Text == textPartNum2.Text)
                {
                    Count_Val2 = 1;
                    textCount2.Text = "0001";
                    textPartNum2.Text = "";
                }

            }

            sw.WriteLine("{0},{1},{2},{3},{4}", Convert.ToString(bSingle_Lot_Mode), textPartNum.Text, textPartNum2.Text, textCount.Text, textCount2.Text);
            

            sw.Close();
        }
        public void DATE_Save()
        {
            string SavePath = AppDomain.CurrentDomain.BaseDirectory;        // 현재 프로세서가 실행되고 있는 디렉토리 위치

            string Savedir = SavePath + @"\Data";                          // 저장할 위치 폴더의 스트링 값(프로세서가 실행되는 위치+저장 폴더 위치)

            DirectoryInfo di = new DirectoryInfo(Savedir);                  // 저장할 폴더의 정보를 반환받음
            if (di.Exists == false)                                         // 저장할 폴더가 존재하지 않으면
            {
                di.Create();                                                // 저장할 폴더 생성
            }
            string FileName = string.Format("Data\\DATE.ini");     // 저장 폴더 + 파일명을 스트링으로 저장(카드번호, 축 번호)

            StreamWriter sw = new StreamWriter(SavePath + FileName);                                // 파을을 저장하기 위해 파일 스트림 생성 ( 프로세서 생성 위치 + (저장폴더+파일명))


            sw.WriteLine("{0}", sBaseDate);
            sw.Close();
        }
        public void Design_Save()
        {
            string SavePath = AppDomain.CurrentDomain.BaseDirectory;        // 현재 프로세서가 실행되고 있는 디렉토리 위치

            string Savedir = SavePath + @"\Data";                          // 저장할 위치 폴더의 스트링 값(프로세서가 실행되는 위치+저장 폴더 위치)

            DirectoryInfo di = new DirectoryInfo(Savedir);                  // 저장할 폴더의 정보를 반환받음
            if (di.Exists == false)                                         // 저장할 폴더가 존재하지 않으면
            {
                di.Create();                                                // 저장할 폴더 생성
            }
            string FileName = string.Format("Data\\Design.ini");     // 저장 폴더 + 파일명을 스트링으로 저장(카드번호, 축 번호)

            StreamWriter sw = new StreamWriter(SavePath + FileName);                                // 파을을 저장하기 위해 파일 스트림 생성 ( 프로세서 생성 위치 + (저장폴더+파일명))


            sw.WriteLine("{0}_{1}_{2}_{3}_{4}", Design_Data[0], Design_Data[1], Design_Data[2], Design_Data[3], Design_Data[4]);
            sw.Close();
        }

        public void Task_Load()
        {
            func_AddLog("Process Count Load");
            string ReadPath = AppDomain.CurrentDomain.BaseDirectory;        // 현재 프로세서가 실행되고 있는 디렉토리 위치
            string FileName = string.Format("Data\\Task.ini");        //파일을 로드할 위치와 파일 이름(저장폴더명+파일이름, 카드번호, 축 번호)

            string fstr;                                                    // 출력할 인자의 모든 값을 넣어줄 스트링 변수
            string[] m_StatusArr = new string[9];                              // 나눠준 각각의 인자의 값을 넣어줄 배열
            try
            {
                StreamReader sr = new StreamReader(ReadPath + FileName);        // 파일 스트림으로 읽음 (현재디토리 위치 + ( 저장폴더 + 파일이름))

                fstr = sr.ReadLine();                                       // 열에 들어갈 모든 인자값을 스트링으로 저장
                sr.Close();                                                    // 파일 스트림을 닫는다
                m_StatusArr = fstr.Split(",".ToCharArray());                   // , 단위로 스트링을 분해하여 각각 배열에 넣어줌
                                                                               //lb_TOTAL_COUNT.Text = m_StatusArr[0];
                bSingle_Lot_Mode = Convert.ToInt16(m_StatusArr[0]);
                textPartNum.Text = m_StatusArr[1];
                textPartNum2.Text = m_StatusArr[2];
                textCount.Text = m_StatusArr[3];
                textCount2.Text = m_StatusArr[4];

                textIP_1.Text = m_StatusArr[5];
                textIP_2.Text = m_StatusArr[6];
                textPort_1.Text = m_StatusArr[7];
                textPort_2.Text = m_StatusArr[8];

             
                //textCount.Text = m_StatusArr[1];
                // textCount2.Text = m_StatusArr[2];

                //iYield_Total = Convert.ToInt32(lb_TOTAL_COUNT.Text);
                Count_Val = Convert.ToInt32(textCount.Text);
                Count_Val2 = Convert.ToInt32(textCount2.Text);
            }
            catch (Exception)
            {
                func_AddLog("Process Count file not Exists");
            }

        }
        public void Port_Load()
        {
            func_AddLog("port setup file load");
            string ReadPath = AppDomain.CurrentDomain.BaseDirectory;        // 현재 프로세서가 실행되고 있는 디렉토리 위치
            string FileName = string.Format("Data\\Port.ini");        //파일을 로드할 위치와 파일 이름(저장폴더명+파일이름, 카드번호, 축 번호)

            string fstr;                                                    // 출력할 인자의 모든 값을 넣어줄 스트링 변수
            string[] m_StatusArr = new string[7];                              // 나눠준 각각의 인자의 값을 넣어줄 배열
            try
            {
                StreamReader sr = new StreamReader(ReadPath + FileName);        // 파일 스트림으로 읽음 (현재디토리 위치 + ( 저장폴더 + 파일이름))

                fstr = sr.ReadLine();                                       // 열에 들어갈 모든 인자값을 스트링으로 저장
                sr.Close();                                                    // 파일 스트림을 닫는다
                m_StatusArr = fstr.Split(",".ToCharArray());                   // , 단위로 스트링을 분해하여 각각 배열에 넣어줌

                bSingle_Lot_Mode = Convert.ToInt16(m_StatusArr[0]);
                textPartNum.Text = m_StatusArr[1];
                textPartNum2.Text = m_StatusArr[2];
                textCount.Text = m_StatusArr[3];
                textCount2.Text = m_StatusArr[4];

               
              

                //sw.WriteLine("{0},{1},{2},{3},{4}", Convert.ToString(bSingle_Lot_Mode), textPartNum, textPartNum2, textCount, textCount2);
                //tB_IP.Text = m_StatusArr[0];
                //tB_IP_PORT.Text = m_StatusArr[1];
                //tB_SERIAL_PORT.Text = m_StatusArr[2];
                //tB_BAUDRATE.Text = m_StatusArr[3];
            }
            catch (Exception)
            {
                func_AddLog("port setup file not Exists");
            }

        }
        public void DATE_Load()
        {
            //func_AddLog("Base date file load");
            string ReadPath = AppDomain.CurrentDomain.BaseDirectory;        // 현재 프로세서가 실행되고 있는 디렉토리 위치
            string FileName = string.Format("Data\\DATE.ini");        //파일을 로드할 위치와 파일 이름(저장폴더명+파일이름, 카드번호, 축 번호)

            string fstr;                                                    // 출력할 인자의 모든 값을 넣어줄 스트링 변수
            string[] m_StatusArr = new string[7];                              // 나눠준 각각의 인자의 값을 넣어줄 배열
            try
            {
                StreamReader sr = new StreamReader(ReadPath + FileName);        // 파일 스트림으로 읽음 (현재디토리 위치 + ( 저장폴더 + 파일이름))

                fstr = sr.ReadLine();                                       // 열에 들어갈 모든 인자값을 스트링으로 저장
                sr.Close();                                                    // 파일 스트림을 닫는다
                m_StatusArr = fstr.Split(",".ToCharArray());                   // , 단위로 스트링을 분해하여 각각 배열에 넣어줌

                sBaseDate = m_StatusArr[0];

                //sNowDate = DateTime.Now.ToString("yyyyMMdd");

                //if (Convert.ToInt64(sBaseDate) < Convert.ToInt64(sNowDate))
                //{
                //    sBaseDate = sNowDate;
                //    DATE_Save();
            
                //    Count_Val = 0;
                //    textCount.Text = "0000";
                //    Count_Val2 = 0;
                //    textCount2.Text = "0000";
                //    Task_Save();
                //}

                //sw.WriteLine("{0},{1},{2},{3},{4}", Convert.ToString(bSingle_Lot_Mode), textPartNum, textPartNum2, textCount, textCount2);
                //tB_IP.Text = m_StatusArr[0];
                //tB_IP_PORT.Text = m_StatusArr[1];
                //tB_SERIAL_PORT.Text = m_StatusArr[2];
                //tB_BAUDRATE.Text = m_StatusArr[3];
            }
            catch (Exception)
            {
                func_AddLog("Date setup file not Exists");

                //sNowDate = DateTime.Now.ToString("yyyyMMdd");

                //if (Convert.ToInt64(sBaseDate) < Convert.ToInt64(sNowDate))
                //{
                    sBaseDate = sNowDate;
                    DATE_Save();

                    Count_Val = 1;
                    textCount.Text = "0001";
                    Count_Val2 = 1;
                    textCount2.Text = "0001";
                    Task_Save();
                //}
            }

        }
        public void Design_Load()
        {
            func_AddLog("Design date file load");
            string ReadPath = AppDomain.CurrentDomain.BaseDirectory;        // 현재 프로세서가 실행되고 있는 디렉토리 위치
            string FileName = string.Format("Data\\Design.ini");        //파일을 로드할 위치와 파일 이름(저장폴더명+파일이름, 카드번호, 축 번호)

            string fstr;                                                    // 출력할 인자의 모든 값을 넣어줄 스트링 변수
            string[] m_StatusArr = new string[10];                              // 나눠준 각각의 인자의 값을 넣어줄 배열
            try
            {
                StreamReader sr = new StreamReader(ReadPath + FileName);        // 파일 스트림으로 읽음 (현재디토리 위치 + ( 저장폴더 + 파일이름))

                fstr = sr.ReadLine();                                       // 열에 들어갈 모든 인자값을 스트링으로 저장
                sr.Close();                                                    // 파일 스트림을 닫는다
                m_StatusArr = fstr.Split("_".ToCharArray());                   // , 단위로 스트링을 분해하여 각각 배열에 넣어줌

                for (int i = 0; i < 5; i++)
                {
                    Design_Data[i] = m_StatusArr[i];
                }
            }
            catch (Exception)
            {
                func_AddLog("Design setup file not Exists");
            }

        }

        private void BTN_PLC_READ_Click(object sender, EventArgs e)
        {
            sendGetData();
        }
        private DateTime MonentDelay(int ms)
        {
            DateTime thisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, ms);
            DateTime afterMoment = thisMoment.Add(duration);

            while(afterMoment > thisMoment)
            {
                thisMoment = DateTime.Now;
            }
            return DateTime.Now;
        }
        public void sendGetData()
        {
            //byte[] bySendBuff = new byte[64];

            //// 05 30 30 52 53 53 30 31 30 36 25 44 57 37 31 30 04
            ////ENQ 0 0 R S S 0 1 0 6 % D W 7 1 0 EOT 
            //string sAdd = "700";
            //for (int i = 0; i < 11; i++)
            //{
            //    bySendBuff[0] = 0x05; //
            //    bySendBuff[1] = 0x30;
            //    bySendBuff[2] = 0x30;
            //    bySendBuff[3] = 0x52;
            //    bySendBuff[4] = 0x53;
            //    bySendBuff[5] = 0x53;
            //    bySendBuff[6] = 0x30;
            //    bySendBuff[7] = 0x31;
            //    bySendBuff[8] = 0x30;
            //    bySendBuff[9] = 0x36;
            //    bySendBuff[10] = 0x25;
            //    bySendBuff[11] = 0x44;
            //    bySendBuff[12] = 0x57;

            //    byte[] bytes = Encoding.ASCII.GetBytes(sAdd);
            //    bySendBuff[13] = bytes[0];
            //    bySendBuff[14] = bytes[1];
            //    bySendBuff[15] = bytes[2];
            //    bySendBuff[16] = 0x04;
            //    try
            //    {
            //        SP_PLC.Write(bySendBuff, 0, 17);
            //    }
            //    catch(Exception)
            //    {
            //        func_AddLog("Serial Command Write fail");
            //    }
            //    int isadd = Convert.ToInt32(sAdd);
            //    isadd += 2;

            //    sAdd = Convert.ToString(isadd);
            //    int iloopCount = 20;
            //    string m_sLaser_Serial = "";

            //    while (iloopCount > 0)
            //    {
            //        try
            //        {
            //            m_sLaser_Serial = SP_PLC.ReadExisting();
            //        }
            //        catch (Exception)
            //        {
            //        }
            //        int m_StrLength = m_sLaser_Serial.Length;
            //        if (m_StrLength == 15)
            //        {
            //          //  func_AddLog(m_sLaser_Serial);
            //            string sgetData;
            //            sgetData = m_sLaser_Serial.Substring(10, 4);
            //          //  func_AddLog(sgetData);
            //            iPLCReadData[i] = Convert.ToInt16(sgetData, 16);
            //            break;
            //        }

            //        iloopCount--;
            //       // MonentDelay(100);
            //        Thread.Sleep(100);
            //    }
            //    if (iloopCount <= 0)
            //    {
            //        iSerialReadFail_Count++;
            //        func_AddLog("Serial recive fail");
            //        if (iSerialReadFail_Count > 5)
            //        {
            //            iSerialReadFail_Count = 0;
            //            //errPopUp.error_MSG_Display("Serial Port DisConnected !!");
            //            //errPopUp.Show();
            //            func_AddLog("Serial Port DisConnected...");
            //            bSerialConnected = false;
            //        }
            //    }
            //}

            //bySendBuff[0] = 0x05; //
            //bySendBuff[1] = 0x30;
            //bySendBuff[2] = 0x30;
            //bySendBuff[3] = 0x57;
            //bySendBuff[4] = 0x53;
            //bySendBuff[5] = 0x53;
            //bySendBuff[6] = 0x30;
            //bySendBuff[7] = 0x31;
            //bySendBuff[8] = 0x30;
            //bySendBuff[9] = 0x36;
            //bySendBuff[10] = 0x25;
            //bySendBuff[11] = 0x44;
            //bySendBuff[12] = 0x57;

            //bySendBuff[13] = 0x38;
            //bySendBuff[14] = 0x30;
            //bySendBuff[15] = 0x30;
            //bySendBuff[16] = 0x30;
            //bySendBuff[17] = 0x30;
            //bySendBuff[18] = 0x30;
            //bySendBuff[19] = 0x31;
            //bySendBuff[20] = 0x04;
            //try
            //{
            //    SP_PLC.Write(bySendBuff, 0, 21);
            //}
            //catch (Exception)
            //{

            //}
            // DataGridInit();
            //DataGridSetDataUpdate();
            

        }
       

        private void tm_PLC_Tick(object sender, EventArgs e)
        {
            //byte[] bySendBuff = new byte[64];

            //// 05 30 30 52 53 53 30 31 30 36 25 44 57 37 31 30 04
            ////ENQ 0 0 R S S 0 1 0 6 % D W 7 1 0 EOT 


            //bySendBuff[0] = 0x05; //
            //bySendBuff[1] = 0x30;
            //bySendBuff[2] = 0x30;
            //bySendBuff[3] = 0x57;
            //bySendBuff[4] = 0x53;
            //bySendBuff[5] = 0x53;
            //bySendBuff[6] = 0x30;
            //bySendBuff[7] = 0x31;
            //bySendBuff[8] = 0x30;
            //bySendBuff[9] = 0x36;
            //bySendBuff[10] = 0x25;
            //bySendBuff[11] = 0x44;
            //bySendBuff[12] = 0x57;

            //bySendBuff[13] = 0x37;
            //bySendBuff[14] = 0x30;
            //bySendBuff[15] = 0x30;
            //bySendBuff[15] = 0x01;
            //bySendBuff[16] = 0x04;
            //try
            //{
            //    SP_PLC.Write(bySendBuff, 0, 17);
            //}
            //catch(Exception)
            //{

            //}
        }

        //private bool Check_BCR_Print()
        //{
        //    int iPrePass = 0;
        //    int iPreFail = 0;
        //    bool bResult = false;
           
        //    if (iPLCReadData[9] == 2)
        //    {
        //        iPrePass = iYield_Pass;
        //        iPreFail = iYield_Fail;
        //        //  iYield_Total = iPLCReadData[0];
        //        //bResult = true;
        //        // func_CSV_LogSave();

           
        //        if (iPLCReadData[1] == iPLCReadData[3])
        //            iYield_Pass = iPLCReadData[3];
        //        else if (iPLCReadData[1] < iPLCReadData[3])
        //            iYield_Pass = iPLCReadData[1];
        //        else
        //            iYield_Pass = iPLCReadData[3];

        //        if (iPLCReadData[2] == iPLCReadData[4])
        //            iYield_Fail = iPLCReadData[4];
        //        else if (iPLCReadData[2] < iPLCReadData[4])
        //            iYield_Fail = iPLCReadData[4];
        //        else
        //            iYield_Fail = iPLCReadData[2];

        //        if(iPrePass+1 <= iYield_Pass)
        //        {
        //            bResult = true;
        //        }
        //        else
        //        {
        //            bResult = false;
        //        }
                    
        //        //iYield_Total = iPLCReadData[0];
        //        //lb_TOTAL_COUNT.Text = Convert.ToString(iYield_Total);
        //        //lb_PASS_COUNT.Text = Convert.ToString(iYield_Pass);
        //        //lb_FAIL_COUNT.Text = Convert.ToString(iYield_Fail);
        //        //PieChartDraw();
        //        if (bResult == true)
        //        {
        //            if (bLogSaveFlag == false && bPGM_Loading==true)
        //            {
        //                Print_QRCode(false);
        //                func_CSV_LogSave(true);
        //                bLogSaveFlag = true;
        //            }
        //        }
        //        else
        //        {
        //            if (bLogSaveFlag == false && bPGM_Loading == true)
        //            {
        //                sPrintQR = "-";
        //                func_CSV_LogSave(false);
        //                bLogSaveFlag = true;
        //            }
        //        }
        //    }
        //    else if (iPLCReadData[9] == 1)
        //    {
        //        iPrePass = iYield_Pass;
        //        iPreFail = iYield_Fail;
        //        //  iYield_Total = iPLCReadData[0];
        //       // bResult = true;
        //        // func_CSV_LogSave();


               
        //        iYield_Pass = iPLCReadData[1];
                        
        //        iYield_Fail = iPLCReadData[2];
               

        //        if (iPrePass + 1 <= iYield_Pass)
        //        {
        //            bResult = true;
        //        }
        //        else
        //        {
        //            bResult = false;
        //        }

        //        iYield_Total = iPLCReadData[0];
        //        lb_TOTAL_COUNT.Text = Convert.ToString(iYield_Total);
        //        lb_PASS_COUNT.Text = Convert.ToString(iYield_Pass);
        //        lb_FAIL_COUNT.Text = Convert.ToString(iYield_Fail);
        //        PieChartDraw();
        //        if (bResult == true)
        //        {
        //            if (bLogSaveFlag == false && bPGM_Loading == true)
        //            {
        //                Print_QRCode(false);
        //                func_CSV_LogSave(true);
        //                bLogSaveFlag = true;
        //            }
        //        }
        //        else
        //        {
        //            if (bLogSaveFlag == false && bPGM_Loading == true)
        //            {
        //                sPrintQR = "-";
        //                func_CSV_LogSave(false);
        //                bLogSaveFlag = true;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        bPGM_Loading = true;
        //        bLogSaveFlag = false;
        //    }
        //    return bResult;
        //}

        //private void btn_RESET_Click(object sender, EventArgs e)
        //{
        //    iYield_Pass = 0;
        //    iYield_Total = 0;
        //    iYield_Fail = 0;

        //    lb_TOTAL_COUNT.Text = Convert.ToString(iYield_Total);
        //    lb_PASS_COUNT.Text = Convert.ToString(iYield_Pass);
        //    lb_FAIL_COUNT.Text = Convert.ToString(iYield_Fail);

        //    Task_Save();

        //}
        private bool FileIsUse(string strFilePath)
        {
            try
            {
                using (System.IO.FileStream fs = new System.IO.FileStream(strFilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.None))
                { //파일 닫기...
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                // strErr = ex.Message.ToString();
                return false;
            }
            return true;
        }

        private bool func_CSV_LogSave(bool bResult)
        {
            string sTemp = "";
            string SavePath = AppDomain.CurrentDomain.BaseDirectory;        // 현재 프로세서가 실행되고 있는 디렉토리 위치
            sTemp = SavePath + @"\Log" + @"\ResultLog";                          // 저장할 위치 폴더의 스트링 값(프로세서가 실행되는 위치+저장 폴더 위치)

           
            sTemp += "\\" + DateTime.Now.ToString("yyyy_MM") + "\\";

            string[] mTemp = new string[3];
            DirectoryInfo di = new DirectoryInfo(sTemp);
            if (di.Exists == false)
            {
                di.Create();
            }

            string pcName = Environment.MachineName;
            sTemp += DateTime.Now.ToString("yyyy_MM_dd") + "_InspectionData.csv";
           
            if (File.Exists(sTemp))
            {
                if (!FileIsUse(sTemp))
                {
                    MessageBox.Show("Log 파일이 사용 중 입니다.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    func_AddLog("Log 파일이 사용 중 입니다.");
                    return false;
                }
            }
            else
            {
                FileStream fsIndex = new FileStream(sTemp, FileMode.Append, FileAccess.Write);
                StreamWriter swHead = new StreamWriter(fsIndex, Encoding.UTF8);

                //swHead.WriteLine("Time, Characteristic, Actual, MIN, MAX, RESULT, MODEL");

                //dataGridView_Data.Rows.Add("D700", "전체 검사 수량", Convert.ToString(iPLCReadData[0]));
                //dataGridView_Data.Rows.Add("D702", "1번 검사 양품 수량", Convert.ToString(iPLCReadData[1]));
                //dataGridView_Data.Rows.Add("D704", "1번 검사 불량 수량", Convert.ToString(iPLCReadData[2]));
                //dataGridView_Data.Rows.Add("D706", "2번 검사 양품 수량", Convert.ToString(iPLCReadData[3]));
                //dataGridView_Data.Rows.Add("D708", "2번 검사 불량 수량", Convert.ToString(iPLCReadData[4]));
                //dataGridView_Data.Rows.Add("D710", "1번 검사 측정 값(실시간)", Convert.ToString(iPLCReadData[5]));
                //dataGridView_Data.Rows.Add("D712", "2번 검사 측정 값(실시간)", Convert.ToString(iPLCReadData[6]));
                //dataGridView_Data.Rows.Add("D714", "1번 검사 판정 값", Convert.ToString(iPLCReadData[7]));
                //dataGridView_Data.Rows.Add("D716", "2번 검사 판정 값", Convert.ToString(iPLCReadData[8]));
                //dataGridView_Data.Rows.Add("D718", "검사 완료/종료", Convert.ToString(iPLCReadData[9]));
                //dataGridView_Data.Rows.Add("D720", "2번검사 커버 배출 상태", Convert.ToString(iPLCReadData[10]));


                swHead.Write("Time,PC Name,sw version,PASS/FAIL, QRCode,");
                swHead.Write("전체 검사 수량,1번 검사 양품 수량,1번 검사 불량 수량,2번 검사 양품 수량,2번 검사 불량 수량,");
                swHead.Write("1번 검사 판정 값 ,2번 검사 판정 값,2번검사 커버 배출 상태");
             
                swHead.WriteLine("");

                swHead.Close();
                fsIndex.Close();
            }

            FileStream fs = new FileStream(sTemp, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

            sw.Write(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ",");
            sw.Write(pcName + ",");
            sw.Write(lb_SWVER.Text + ","); //sPrintQR
            if(bResult == true)
                sw.Write("PASS ,");
            else
                sw.Write("FAIL ,");
            sw.Write(sPrintQR + ",");
            sw.Write(iYield_Total.ToString() + ",");
            sw.Write(iPLCReadData[1].ToString() + ",");
            sw.Write(iPLCReadData[2].ToString() + ",");
            sw.Write(iPLCReadData[3].ToString() + ",");
            sw.Write(iPLCReadData[4].ToString() + ",");
            sw.Write(iPLCReadData[7].ToString() + ",");
            sw.Write(iPLCReadData[8].ToString() + ",");
            sw.Write(iPLCReadData[10].ToString() + ",");

            sw.WriteLine("");

            sw.Close();
            fs.Close();

            return true;
        }
        private bool MouseWait
        {
            set
            {
                if (value)
                    Cursor = Cursors.WaitCursor;
                else
                    Cursor = Cursors.Default;
            }
        }
        private void btn_LOGSAVE_Click(object sender, EventArgs e)
        {
            func_CSV_LogSave(true);
        }

        private void RefreshCOM_USBList()
        {
            cbUSBPorts.DataSource = null;
            cbUSBPorts.Items.Clear();
            Dictionary<string, string> cbObj = new Dictionary<string, string>();
            switch (cbInterfaces.SelectedIndex)
            {
                //case 1:
                //    foreach (string comport in SATOPrinter.GetCOMList())
                //    {
                //        cbObj.Add(comport, comport);
                //    }
                //    break;
                //case 2:
                //    foreach (string lptport in SATOPrinter.GetLPTList())
                //    {
                //        cbObj.Add(lptport, lptport);
                //    }
                //    break;
                case 3:

                    foreach (Printer.USBInfo usbPorts in SATOPrinter.GetUSBList())
                    {
                        cbObj.Add(usbPorts.PortID, usbPorts.Name);
                        func_AddLog("USB 1 Open : "+ usbPorts.PortID+ usbPorts.Name);
                        bTCPConnected = true;
                    }
                    break;
            }

            if (cbObj.Count > 0)
            {
                cbUSBPorts.DataSource = new BindingSource(cbObj, null);
                cbUSBPorts.DisplayMember = "Value";
                cbUSBPorts.ValueMember = "Key";
                cbUSBPorts.SelectedIndex = 0;
            }
            else
            {
                bTCPConnected = false;
            }
            //SetInterface();
        }
        private void RefreshCOM_USBList2()
        {
            cbUSBPorts2.DataSource = null;
            cbUSBPorts2.Items.Clear();
            Dictionary<string, string> cbObj = new Dictionary<string, string>();
            switch (cbInterfaces2.SelectedIndex)
            {
                //case 1:
                //    foreach (string comport in SATOPrinter.GetCOMList())
                //    {
                //        cbObj.Add(comport, comport);
                //    }
                //    break;
                //case 2:
                //    foreach (string lptport in SATOPrinter.GetLPTList())
                //    {
                //        cbObj.Add(lptport, lptport);
                //    }
                //    break;
                case 3:

                    foreach (Printer.USBInfo usbPorts2 in SATOPrinter2.GetUSBList())
                    {
                        cbObj.Add(usbPorts2.PortID, usbPorts2.Name);
                        func_AddLog("USB 2 Open : " + usbPorts2.PortID + usbPorts2.Name);
                        bTCPConnected = true;
                    }
                    break;
            }

            if (cbObj.Count > 0)
            {
                cbUSBPorts2.DataSource = new BindingSource(cbObj, null);
                cbUSBPorts2.DisplayMember = "Value";
                cbUSBPorts2.ValueMember = "Key";
                cbUSBPorts2.SelectedIndex = 0;
            }
            else
            {
                bTCPConnected = false;
            }
            //SetInterface2();
        }


        private void cbInterfaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnQuery.Enabled = true;
           // groupBox2.Enabled = true;
            switch (cbInterfaces.SelectedIndex)
            {
                //case 0:
                //    panelSocket.Show();
                //    panelUSB.Hide();
                //    pnlDriver.Hide();
                //    chkPermanent.Enabled = true;
                //    chkPermanent.Checked = false;
                //    txtTimeout.Enabled = true;
                //    break;
                //case 1:
                //    RefreshCOM_USBList();
                //    panelUSB.Show();
                //    panelSocket.Hide();
                //    pnlDriver.Hide();
                //    chkPermanent.Enabled = true;
                //    chkPermanent.Checked = false;
                //    txtTimeout.Enabled = true;
                //    break;
                //case 2:
                //    RefreshCOM_USBList();
                //    panelUSB.Show();
                //    panelSocket.Hide();
                //    pnlDriver.Hide();
                //    chkPermanent.Enabled = true;
                //    chkPermanent.Checked = false;
                //    txtTimeout.Enabled = true;
                //    break;
                case 3:
                    RefreshCOM_USBList();
                    panelUSB.Show();
                   // panelSocket.Hide();
                   // pnlDriver.Hide();
                   // chkPermanent.Enabled = true;
                  //  chkPermanent.Checked = false;
                   // txtTimeout.Enabled = true;
                    break;
                //case 4:
                //    panelUSB.Hide();
                //    panelSocket.Hide();
                //    pnlDriver.Show();
                //    chkPermanent.Enabled = false;
                //    chkPermanent.Checked = false;
                //    btnQuery.Enabled = false;
                //    groupBox2.Enabled = false;
                //    txtTimeout.Enabled = false;
                //    break;
            }

            //if (chkPermanent.Checked)
            //{
            //    SATOPrinter.Disconnect();
            //}
        }
        private void cbInterfaces_SelectedIndexChanged2(object sender, EventArgs e)
        {
            btnQuery.Enabled = true;
            // groupBox2.Enabled = true;
            switch (cbInterfaces.SelectedIndex)
            {
                //case 0:
                //    panelSocket.Show();
                //    panelUSB.Hide();
                //    pnlDriver.Hide();
                //    chkPermanent.Enabled = true;
                //    chkPermanent.Checked = false;
                //    txtTimeout.Enabled = true;
                //    break;
                //case 1:
                //    RefreshCOM_USBList();
                //    panelUSB.Show();
                //    panelSocket.Hide();
                //    pnlDriver.Hide();
                //    chkPermanent.Enabled = true;
                //    chkPermanent.Checked = false;
                //    txtTimeout.Enabled = true;
                //    break;
                //case 2:
                //    RefreshCOM_USBList();
                //    panelUSB.Show();
                //    panelSocket.Hide();
                //    pnlDriver.Hide();
                //    chkPermanent.Enabled = true;
                //    chkPermanent.Checked = false;
                //    txtTimeout.Enabled = true;
                //    break;
                case 3:
                    RefreshCOM_USBList2();
                    panelUSB.Show();
                    // panelSocket.Hide();
                    // pnlDriver.Hide();
                    // chkPermanent.Enabled = true;
                    //  chkPermanent.Checked = false;
                    // txtTimeout.Enabled = true;
                    break;
                    //case 4:
                    //    panelUSB.Hide();
                    //    panelSocket.Hide();
                    //    pnlDriver.Show();
                    //    chkPermanent.Enabled = false;
                    //    chkPermanent.Checked = false;
                    //    btnQuery.Enabled = false;
                    //    groupBox2.Enabled = false;
                    //    txtTimeout.Enabled = false;
                    //    break;
            }

            //if (chkPermanent.Checked)
            //{
            //    SATOPrinter.Disconnect();
            //}
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false;
            RefreshCOM_USBList();
            btnRefresh.Enabled = true;
        }
        private void btnRefresh_Click2(object sender, EventArgs e)
        {
            btnRefresh2.Enabled = false;
            RefreshCOM_USBList2();
            btnRefresh2.Enabled = true;
        }
        private Dictionary<string, char> ControlCharList()
        {
            Dictionary<string, char> ctr = new Dictionary<string, char>();
            ctr.Add("[NUL]", '\u0000');
            ctr.Add("[SOH]", '\u0001');
            ctr.Add("[STX]", '\u0002');
            ctr.Add("[ETX]", '\u0003');
            ctr.Add("[EOT]", '\u0004');
            ctr.Add("[ENQ]", '\u0005');
            ctr.Add("[ACK]", '\u0006');
            ctr.Add("[BEL]", '\u0007');
            ctr.Add("[BS]", '\u0008');
            ctr.Add("[HT]", '\u0009');
            ctr.Add("[LF]", '\u000A');
            ctr.Add("[VT]", '\u000B');
            ctr.Add("[FF]", '\u000C');
            ctr.Add("[CR]", '\u000D');
            ctr.Add("[SO]", '\u000E');
            ctr.Add("[SI]", '\u000F');
            ctr.Add("[DLE]", '\u0010');
            ctr.Add("[DC1]", '\u0011');
            ctr.Add("[DC2]", '\u0012');
            ctr.Add("[DC3]", '\u0013');
            ctr.Add("[DC4]", '\u0014');
            ctr.Add("[NAK]", '\u0015');
            ctr.Add("[SYN]", '\u0016');
            ctr.Add("[ETB]", '\u0017');
            ctr.Add("[CAN]", '\u0018');
            ctr.Add("[EM]", '\u0019');
            ctr.Add("[SUB]", '\u001A');
            ctr.Add("[ESC]", '\u001B');
            ctr.Add("[FS]", '\u001C');
            ctr.Add("[GS]", '\u001D');
            ctr.Add("[RS]", '\u001E');
            ctr.Add("[US]", '\u001F');
            ctr.Add("[DEL]", '\u007F');
            return ctr;
        }

        private string ControlCharConvert(string data)
        {
            Dictionary<char, string> chrList = ControlCharList().ToDictionary(x => x.Value, x => x.Key);
            foreach (char key in chrList.Keys)
            {
                data = data.Replace(key.ToString(), chrList[key]);
            }
            return data;
        }
        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.RestoreDirectory = false;
            openFileDialog1.Filter = "Command file (*.txt,*.prn)|*.txt;*.prn|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 0;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (System.IO.File.Exists(openFileDialog1.FileName))
                    {
                        byte[] cmddata = System.IO.File.ReadAllBytes(openFileDialog1.FileName);
                        MouseWait = true;
                        try
                        {
                            txtSend.Text = ControlCharConvert(Utils.ByteArrayToString(cmddata));
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        MouseWait = false;
                    }
                    else
                    {
                        MessageBox.Show("Error: file not found.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private string ControlCharReplace(string data)
        {
            Dictionary<string, char> chrList = ControlCharList();
            foreach (string key in chrList.Keys)
            {
                data = data.Replace(key, chrList[key].ToString());
            }
            return data;
        }
        private void SetInterface()
        {
            try
            {
                int timeOut = int.Parse(txtTimeout.Text);
                if (timeOut <= 1000)
                    timeOut = 1000;
                SATOPrinter.Timeout = timeOut;

                switch (cbInterfaces.SelectedIndex)
                {
                    case 0: //Socket
                        SATOPrinter.Interface = Printer.InterfaceType.TCPIP;
                        //SATOPrinter.TCPIPAddress = "192.168.3.1";
                        //SATOPrinter.TCPIPPort = "9100";
                        SATOPrinter.TCPIPAddress = textIP_1.Text;
                        SATOPrinter.TCPIPPort = textPort_1.Text;
                        break;
                    //case 1: //COM
                    //    SATOPrinter.Interface = Printer.InterfaceType.COM; ;
                    //    if (cbUSBPorts.SelectedItem != null)
                    //        SATOPrinter.COMPort = ((KeyValuePair<string, string>)cbUSBPorts.SelectedItem).Key;
                    //    break;
                    //case 2: //LPT
                    //    SATOPrinter.Interface = Printer.InterfaceType.LPT;
                    //    if (cbUSBPorts.SelectedItem != null)
                    //        SATOPrinter.LPTPort = ((KeyValuePair<string, string>)cbUSBPorts.SelectedItem).Key;
                    //    break;
                    case 3: //USB
                        SATOPrinter.Interface = Printer.InterfaceType.USB;
                        if (cbUSBPorts.SelectedItem != null)
                        {
                            SATOPrinter.USBPortID = ((KeyValuePair<string, string>)cbUSBPorts.SelectedItem).Key;
                          
                        }
                            
                        break;
                    default:
                        MessageBox.Show("Error : Invalid Interface Selection!");
                        break;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("SetInterface Error :" +ex.Message);
            }
        }
        private void SetInterface2()
        {
            try
            {
                int timeOut = int.Parse(txtTimeout.Text);
                if (timeOut <= 1000)
                    timeOut = 1000;
                SATOPrinter2.Timeout = timeOut;

                switch (cbInterfaces2.SelectedIndex)
                {
                    case 0: //Socket
                        SATOPrinter2.Interface = Printer.InterfaceType.TCPIP;
                        //SATOPrinter2.TCPIPAddress = "192.168.3.2";
                        //SATOPrinter2.TCPIPPort = "9100";
                        SATOPrinter2.TCPIPAddress = textIP_2.Text;
                        SATOPrinter2.TCPIPPort = textPort_2.Text;
                        break;
                    //case 1: //COM
                    //    SATOPrinter.Interface = Printer.InterfaceType.COM; ;
                    //    if (cbUSBPorts.SelectedItem != null)
                    //        SATOPrinter.COMPort = ((KeyValuePair<string, string>)cbUSBPorts.SelectedItem).Key;
                    //    break;
                    //case 2: //LPT
                    //    SATOPrinter.Interface = Printer.InterfaceType.LPT;
                    //    if (cbUSBPorts.SelectedItem != null)
                    //        SATOPrinter.LPTPort = ((KeyValuePair<string, string>)cbUSBPorts.SelectedItem).Key;
                    //    break;
                    case 3: //USB
                        SATOPrinter2.Interface = Printer.InterfaceType.USB;
                        if (cbUSBPorts2.SelectedItem != null)
                        {
                            SATOPrinter2.USBPortID = ((KeyValuePair<string, string>)cbUSBPorts2.SelectedItem).Key;
                        }

                        break;
                    default:
                        MessageBox.Show("Error : Invalid Interface Selection!");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SetInterface Error :" + ex.Message);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSend.Text)) return;     // Send Data가 없을 경우 Return.

            MouseWait = true;
            try
            {

                byte[] cmddata = Utils.StringToByteArray(ControlCharReplace(txtSend.Text));

                //if (cbInterfaces.SelectedIndex == 4)
                //{
                //    if (cbDriver.SelectedValue != null)
                //    {
                //        SATODriver.SendRawData(cbDriver.SelectedValue.ToString(), cmddata);
                //    }
                //    else
                //    {
                //        MessageBox.Show("Please select SATO printer driver from drop down list");
                //    }
                //}
                //else
                //{
                     SetInterface();
                    SATOPrinter.Send(cmddata);
               // }
            }
            catch (Exception ex)
            {
                bTCPConnected = false;

                MessageBox.Show(ex.Message);
            }
            MouseWait = false;
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            //this.Invoke(new EventHandler(ReadMCU));
            QR_Print(0);
            ////if (string.IsNullOrEmpty(txtSend.Text)) return;

            //MouseWait = true;
            //try
            //{

            //    string st1, st2, st3, st4, st5, st6, st7, st8, st9, st10, st11;
            //   st1 = "[STX][ESC]A[ESC]A3V+00000H+0000[ESC]CS6[ESC]#F5[ESC]A1V00256H0200[ESC]Z[ETX][STX][ESC]A[ESC]PS[ESC]WK12345[ESC]%2[ESC]H0164[ESC]V00227[ESC]2D30,L,05,1,0[ESC]DN0026,";
            //    //st1 = "[STX][ESC]A[ESC]A3V+00000H+0000[ESC]CS6[ESC]#F5[ESC]A1V00256H0200[ESC]Z[ETX][STX][ESC]A[ESC]PS[ESC]WKfinal[ESC]%2[ESC]H0164[ESC]V00227[ESC]2D30,L,05,1,0[ESC]DN0026,";
            //    // st2 = "AJL75317401";
            //    if (string.IsNullOrEmpty(textPartNum.Text))
            //    {
            //        st2 = "TESTLOT@123";
            //    }
            //    else
            //    {
            //        st2 = textPartNum.Text;
            //    }

            //    st3 = "[CR][LF]";

            //    //st4 = "20220914 ";
            //    if (string.IsNullOrEmpty(textDate.Text))
            //    {
            //        st4 = DateTime.Now.ToString("yyyyMMdd ");
            //    }
            //    else
            //    {
            //        st4 = textDate.Text + " ";
            //    }
            //    // st5 = "0001";
            //    if (string.IsNullOrEmpty(textCount.Text))
            //    {
            //        st5 = "0001";
            //    }
            //    else
            //    {
            //        Count_Val = Convert.ToInt32(textCount.Text);
            //        textCount.Text = String.Format("{0:D04}", Count_Val);

            //        st5 = textCount.Text;
            //    }
            //    st6 = "[ESC]%2[ESC]H0164[ESC]V00084[ESC]P02[ESC]RH0,SATO0.ttf,0,020,020,";


            //    //st7 = "AJL75317401";
            //    if (string.IsNullOrEmpty(textPartNum.Text))
            //    {
            //        st7 = "TESTLOT@123";
            //    }
            //    else
            //    {
            //        st7 = textPartNum.Text;
            //    }
            //    st8 = "[ESC]%2[ESC]H0164[ESC]V00063[ESC]P02[ESC]RH0,SATO0.ttf,0,020,020,";
            //    //st8 = "[ESC]%2[ESC]H0164[ESC]V00069[ESC]P02[ESC]RH0,SATO0.ttf,0,020,020,";


            //    // st9 = "20220914 ";
            //    if (string.IsNullOrEmpty(textDate.Text))
            //    {
            //        st9 = DateTime.Now.ToString("yyyyMMdd ");
            //    }
            //    else
            //    {
            //        st9 = textDate.Text + " ";
            //    }
            //    // st10 = "0001";
            //    if (string.IsNullOrEmpty(textCount.Text))
            //    {
            //        st10 = "0001";
            //    }
            //    else
            //    {
            //        Count_Val = Convert.ToInt32(textCount.Text);
            //        textCount.Text = String.Format("{0:D04}", Count_Val);
            //        st10 = textCount.Text;



            //       // Count_Val++;
            //       // textCount.Text = String.Format("{0:D04}", Count_Val);

            //    }
            //    st11 = "[ESC]%2[ESC]H0164[ESC]V00042[ESC]P02[ESC]RH0,SATO0.ttf,0,020,020,Result : OK[ESC]Q1[ESC]Z[ETX]";
            //   // st11 = "[ESC]%2[ESC]H0164[ESC] V00054[ESC]P02[ESC] RH0, SATO0.ttf,0,020,020,Result : OK[ESC]Q1[ESC]Z[ETX]";

            //    // txtSend.Text = "[STX][ESC]A[ESC]A3V+00000H+0000[ESC]CS6[ESC]#F5[ESC]A1V00256H0200[ESC]Z[ETX][STX][ESC]A[ESC]PS[ESC]WK12345678912[ESC]%2[ESC]H0164[ESC]V00227[ESC]2D30,L,05,1,0[ESC]DN0026,AJL75317401[CR][LF]20220914 0001[ESC]%2[ESC]H0164[ESC]V00084[ESC]P02[ESC]RH0,SATO0.ttf,0,020,020,AJL75317401[ESC]%2[ESC]H0164[ESC]V00063[ESC]P02[ESC]RH0,SATO0.ttf,0,020,020,20220914 0001[ESC]%2[ESC]H0164[ESC]V00042[ESC]P02[ESC]RH0,SATO0.ttf,0,020,020,Result : OK[ESC]Q1[ESC]Z[ETX]";
            //    txtSend.Text = st1 + st2 + st3 + st4 + st5 + st6 + st7 + st8 + st9 + st10 + st11;

            //    byte[] cmddata = Utils.StringToByteArray(ControlCharReplace(txtSend.Text));
            //    // byte[] cmddata = "[STX][ESC]A[ESC]A3V+00000H+0000[ESC]CS6[ESC]#F5[ESC]A1V00256H0200[ESC]Z[ETX][STX][ESC]A[ESC]PS[ESC]WK12345678912[ESC]%2[ESC]H0164[ESC]V00227[ESC]2D30,L,05,1,0[ESC]DN0026,AJL75317401[CR][LF]20220914 0001[ESC]%2[ESC]H0164[ESC]V00084[ESC]P02[ESC]RH0,SATO0.ttf,0,020,020,AJL75317401[ESC]%2[ESC]H0164[ESC]V00063[ESC]P02[ESC]RH0,SATO0.ttf,0,020,020,20220914 0001[ESC]%2[ESC]H0164[ESC]V00042[ESC]P02[ESC]RH0,SATO0.ttf,0,020,020,Result : OK[ESC]Q1[ESC]Z[ETX]";

            //    //if (cbInterfaces.SelectedIndex == 4)
            //    //{
            //    //    if (cbDriver.SelectedValue != null)
            //    //    {
            //    //        SATODriver.SendRawData(cbDriver.SelectedValue.ToString(), cmddata);
            //    //    }
            //    //    else
            //    //    {
            //    //        MessageBox.Show("Please select SATO printer driver from drop down list");
            //    //    }
            //    //}
            //    //else
            //    //{
            //    // cmddata = "[STX][ESC]A[ESC]A3V+00000H+0000[ESC]CS6[ESC]#F5[ESC]A1V00256H0200[ESC]Z[ETX][STX][ESC]A[ESC]PS[ESC]WK12345678912[ESC]%2[ESC]H0164[ESC]V00227[ESC]2D30,L,05,1,0[ESC]DN0026,AJL75317401[CR][LF]20220914 0001[ESC]%2[ESC]H0164[ESC]V00084[ESC]P02[ESC]RH0,SATO0.ttf,0,020,020,AJL75317401[ESC]%2[ESC]H0164[ESC]V00063[ESC]P02[ESC]RH0,SATO0.ttf,0,020,020,20220914 0001[ESC]%2[ESC]H0164[ESC]V00042[ESC]P02[ESC]RH0,SATO0.ttf,0,020,020,Result : OK[ESC]Q1[ESC]Z[ETX]";
            //    SetInterface();
            //    SATOPrinter.Send(cmddata);



            //    // }
            //}
            //catch (Exception ex)
            //{
            //    bTCPConnected = false;

            //    MessageBox.Show(ex.Message);
            //}
            //MouseWait = false;
        }
        private void btnPrint_Click2(object sender, EventArgs e)
        {
            QR_Print(1);
        }
        private void btnTEST_Click(object sender, EventArgs e)
        {

                Count_Val = 1;
                textCount.Text = "0001";
                Task_Save();

            //textCount.Text = "0000"+Count_Val;
            //textCount.Text = "0001";
            //int n_num = Convert.ToInt32(textCount.Text);
            // Count_Val++;


            // textCount.Text = String.Format("{0:D04}", Count_Val);
        }
        private void btnSAVE_Click(object sender, EventArgs e)
        {
            if (textPartNum.Text.Length != 11)
            {
                MessageBox.Show("Stage1 Lot를 확인하세요(11자리)");
                return;
            }
            if (textPartNum2.Text.Length != 11)
            {
                MessageBox.Show("Stage2 Lot를 확인하세요(11자리)");
                return;
            }


            if (textCount.Text.Length != 4)
            {
                MessageBox.Show("Stage1 Count를 확인하세요(4자리)");
                return;
            }
            if (textCount2.Text.Length != 4)
            {
                MessageBox.Show("Stage2 Count를 확인하세요(4자리)");
                return;
            }

            Task_Save();


            //textCount.Text = "0000"+Count_Val;
            //textCount.Text = "0001";
            //int n_num = Convert.ToInt32(textCount.Text);
            // Count_Val++;


            // textCount.Text = String.Format("{0:D04}", Count_Val);
        }
        private void btnTEST_Click2(object sender, EventArgs e)
        {
            Count_Val = 1;
            textCount2.Text = "0001";
            Task_Save();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSend.Text = "";
            //rtxtRecv.Text = "";
            //txtTotalRecvBytes.Text = "0";
            txtSend.Focus();
        }

        private void cSingleLot_CheckedChanged(object sender, EventArgs e)
        {
            //if (cSingleLot.Checked)
            //{
            //    bSingle_Lot_Mode = 1;
            //}
            //else
            //{
            //    bSingle_Lot_Mode = 0;
            //}
            //if (bSingle_Lot_Mode == 0)
            //{
            //    bSingle_Lot_Mode = 1;
            //}
            //else
            //{
            //    bSingle_Lot_Mode = 0;
            //}
           // Port_Save();
            //.Checked(cSingleLot)
        }

        private void textPartNum_TextChanged(object sender, EventArgs e)
        {
           // Port_Save();
        }

        private void textPartNum2_TextChanged(object sender, EventArgs e)
        {
           // Port_Save();
        }

        private void textCount_TextChanged(object sender, EventArgs e)
        {
           // Port_Save();
        }

        private void textCount2_TextChanged(object sender, EventArgs e)
        {
            //Port_Save();
        }

        private void cbUSBPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SetInterface();
        }

        private void cbUSBPorts2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SetInterface2();
        }

        private void textPort_1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

