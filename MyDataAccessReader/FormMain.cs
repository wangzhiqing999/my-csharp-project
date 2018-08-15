using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Reflection;
using System.IO;



 
using Velocity = NVelocity.App.Velocity; 
using VelocityContext = NVelocity.VelocityContext; 
using Template = NVelocity.Template; 
using ParseErrorException = NVelocity.Exception.ParseErrorException; 
using ResourceNotFoundException = NVelocity.Exception.ResourceNotFoundException; 





namespace MyDataAccessReader
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            
        }


        /// <summary>
        /// 初始化.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            string[] templateFiles = Directory.GetFiles("template", "*.*.vm"); 
            this.cboTemplate.DataSource = templateFiles;


            string outputPath = System.Environment.CurrentDirectory + "\\output";
            if (!Directory.Exists(outputPath))
            {
                Directory.CreateDirectory(outputPath);
            }

            this.fbdOutputPath.SelectedPath = outputPath;
            this.txtOutputPath.Text =outputPath;
        }




        /// <summary>
        /// 选择文件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            if (this.ofdDll.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtDllFile.Text = this.ofdDll.FileName;
            }
        }




        private List<Type> allTypeList;


        
        /// <summary>
        /// 读取.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRead_Click(object sender, EventArgs e)
        {
            // 注意： 这里使用 LoadFrom， 而不是 LoadFile.
            Assembly assembly = System.Reflection.Assembly.LoadFrom(this.txtDllFile.Text);

            this.clbModel.Items.Clear();

            allTypeList = assembly.GetExportedTypes().ToList();
            foreach (Type t in allTypeList)
            {
                if (t.FullName.Contains(".Model."))
                {
                    this.clbModel.Items.Add(t.FullName);
                }                
            }

            for (int i = 0; i < this.clbModel.Items.Count; i ++ )
            {
                this.clbModel.SetItemChecked(i, true);
            }
        }



        /// <summary>
        /// 选择输出路径.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectOutputPath_Click(object sender, EventArgs e)
        {
            if (this.fbdOutputPath.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtOutputPath.Text = this.fbdOutputPath.SelectedPath;
            }
        }



        /// <summary>
        /// 生成.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, EventArgs e)
        {
            foreach (var model in this.clbModel.CheckedItems)
            {
                BuildOneFile(model.ToString());
            }

            MyMessage.Success("处理完成！");
        }







        private void BuildOneFile(string className)
        {
            Type modelType = allTypeList.FirstOrDefault(p => p.FullName == className);
            if (modelType == null)
            {
                return;
            }


            //// 取得对象的所有属性.
            //PropertyInfo[] propArray = modelType.GetProperties();
            //foreach (PropertyInfo prop in propArray)
            //{
            //    Console.WriteLine("属性名{0}, CanRead={1}, CanWrite={2}, 数据类型={3}",
            //        prop.Name, prop.CanRead, prop.CanWrite, prop.PropertyType.Name);

            //    Console.WriteLine("是否是抽象类{0}, 是否是类{1}", prop.PropertyType.IsAbstract, prop.PropertyType.IsClass);
            //    Console.WriteLine("是否是数组{0}, 是否是枚举{1}", prop.PropertyType.IsArray, prop.PropertyType.IsEnum);

            //    foreach (var attr in prop.GetCustomAttributes(true))
            //    {
            //        Console.WriteLine("定义在属性上面的自定义特性: {0}", attr);

            //        if (attr is System.ComponentModel.DataAnnotations.DisplayAttribute)
            //        {
            //            System.ComponentModel.DataAnnotations.DisplayAttribute displayAttr = attr as System.ComponentModel.DataAnnotations.DisplayAttribute;
            //            Console.WriteLine("属性显示的标题:{0}", displayAttr.Name);
            //        }
            //    }

            //    Console.WriteLine();
            //}

            //var keyInfo = modelType.GetKeyInfo();
            //Console.WriteLine("keyInfo = {0}", keyInfo);




            // Velocity 初始化. 
            // 从配置文件读取配置信息. 
            Velocity.Init("nvelocity.properties");
            // 创建 Velocity Context 
            VelocityContext context = new VelocityContext();

            // 将数据， 以 Model 作为名称，放入 context. 
            context.Put("Model", modelType);



            // 模版. 
            Template template = null;


            string templateFile = this.cboTemplate.Text;
            



            // 尝试加载模版文件. 
            try
            {
                template = Velocity.GetTemplate(templateFile, "utf-8");
            }
            catch (ResourceNotFoundException)
            {
                MyMessage.Fail(String.Format("未能找到模板文件：{0}", templateFile));
            }
            catch (ParseErrorException pee)
            {
                MyMessage.Fail(String.Format("解析模板文件 {0} 发生了异常！\n{1}", templateFile, pee));
            }



            // 输出文件名， 去掉最后的 .vm
            string outputFileName = templateFile.Substring(0, templateFile.Length - 3);
            // 移除 template 目录.
            outputFileName = outputFileName.Replace("template\\", "");
            // # 替换为类名.
            outputFileName = outputFileName.Replace("#", modelType.Name);


            try
            {
                // 处理模版信息. 
                if (template != null)
                {
                    string fileName = String.Format("{0}\\{1}", this.txtOutputPath.Text, outputFileName);

                    using (StreamWriter sw = new StreamWriter(fileName, false, Encoding.UTF8))
                    {
                        template.Merge(context, sw);
                    }
                }
            }
            catch (Exception ex)
            {
                MyMessage.Fail(String.Format("根据模板文件 {0} 生成文档的过程中，发生了异常！\n{1}", templateFile, ex));
            } 



        }




    }
}
