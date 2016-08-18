Imports SkyEditor.Core

Namespace NDS
    Public Class NDSLibrary
        Inherits Library

        Public Sub New()
            MyBase.New
        End Sub

        Public Sub New(settings As ISettingsProvider)
            MyBase.New(My.Resources.Language.NDSLibraryName, "", settings.GetNDSRomLibraryPath)
        End Sub

        Public Overrides Async Function GetContents(manager As PluginManager) As Task(Of IEnumerable(Of Object))
            Dim out As New List(Of Object)
            For Each item In manager.CurrentIOProvider.GetFiles(Path.Combine(Me.RootPath, Me.RelativePath), "*.nds", True)
                out.Add(Await LibraryNDSRom.GetRom(item, manager))
            Next
            Return out
        End Function

        Public Overrides Function GetSupportedContentTypes() As IEnumerable(Of Type)
            Return {GetType(LibraryNDSRom)}
        End Function

        Public Overrides Function AddContent(content As Object, manager As PluginManager) As Task
            'Todo: copy the ROM
            'Todo: copy the saves
            Throw New NotImplementedException
        End Function
    End Class
End Namespace

