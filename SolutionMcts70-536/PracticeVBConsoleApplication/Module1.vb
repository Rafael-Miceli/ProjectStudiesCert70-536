Imports System.Xml.Linq
Imports System.Xml
Imports System.Xml.XPath
Imports System.IO

Module Module1

    Dim dtSchema As DataTable

    Sub Main()

        'LINQ to Xml

        'Dim Xdoc As XDocument
        'Dim XElem As XElement

        'Xdoc = XDocument.Load("C:\Users\rafael\Documents\Visual Studio 2010\Projetos de Estudos\SolutionMcts70-536\XmlDataPractice.xml")
        ''XElem = XElement.Load("C:\Users\rafael\Documents\Visual Studio 2010\Projetos de Estudos\SolutionMcts70-536\XmlDataPractice.xml")
        ''Where CStr(b.Attribute("in_IDOperacao")) = "857"

        'Dim XmlNode As IEnumerable(Of XElement) = From b In Xdoc.Elements("Practice")
        '                                          Where CStr(b.Element("Funcionalidade").Attribute("in_IDFuncionalidade")) = "16" _
        '                                          And CStr(b.Element("Operacao").Attribute("in_IDOperacao")) = "857"
        '                                          Select b


        'Dim Xmlteste = From Xt In Xdoc...<Operacao> _
        '               Where Xt.@in_IDOperacao = "857" Select Xt

        'For Each ex As XElement In XmlNode
        '    'ex.Attribute("in_IDOperacao").Remove()
        '    Console.WriteLine(ex.HasElements.ToString())
        'Next

        ''XElem.Save("C:\Users\rafael\Documents\Visual Studio 2010\Projetos de Estudos\SolutionMcts70-536\XmlDataPractice.xml")

        'Console.WriteLine(Xdoc.XPathSelectElement("Practice/Funcionalidade/Operacao[@in_IDOperacao = '857']").ToString())


        Dim read As XmlReader = XmlReader.Create("C:\Users\rafael\Downloads\FPW_XML\FPW_LOTACOES_XML.xml")

        Dim ds As New DataSet()

        ds.ReadXml(read)

        dtSchema = ds.Tables(0)

        Dim dcCodEmpresa As New DataColumn("Codigo Empresa", GetType(String))

        dtSchema.Columns.Add(dcCodEmpresa)

        For i As Integer = 0 To dtSchema.Rows.Count - 1
            dtSchema.Rows(i)("Codigo Empresa") = dtSchema.Rows(i)("LOCODEMP").ToString() & dtSchema.Rows(i)("LOCODLOT").ToString().Substring(0, 3)
        Next

        dtSchema.WriteXml("teste.xml")

        Console.ReadKey()

    End Sub

End Module
