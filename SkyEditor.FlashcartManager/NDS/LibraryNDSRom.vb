Imports SkyEditor.Core
Imports SkyEditor.ROMEditor

Namespace NDS
    ''' <summary>
    ''' Represents an NDS Rom that exists in the PC library, including saves.
    ''' </summary>
    Public Class LibraryNDSRom
        Inherits BaseNDSRom
        Protected Sub New()
            MyBase.New
        End Sub

        ''' <summary>
        ''' Opens a <see cref="LibraryNDSRom"/> from disk.
        ''' </summary>
        ''' <param name="filename">Full path of the NDS ROM.</param>
        ''' <param name="manager">Instance of the current plugin manager.</param>
        ''' <returns></returns>
        Public Shared Function GetRom(filename As String, manager As PluginManager) As Task(Of LibraryNDSRom)
            Dim r As New LibraryNDSRom
            r.ROM = New GenericNDSRom(filename, True, False, manager.CurrentIOProvider)
            r.Saves = New Dictionary(Of String, Object)

            'Detect saves
            Dim possibleFilenames As New List(Of String)

            'Get saves from /Saves/XXXX/*.sav
            Dim savesDir = Path.Combine(Path.GetDirectoryName(filename), "saves", r.ROM.GameCode)
            If manager.CurrentIOProvider.DirectoryExists(savesDir) Then
                possibleFilenames.AddRange(manager.CurrentIOProvider.GetFiles(savesDir, "*.sav", True))
            End If

            Return Task.FromResult(r)
        End Function
    End Class
End Namespace
