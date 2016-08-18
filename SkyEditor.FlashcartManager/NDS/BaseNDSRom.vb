Imports SkyEditor.ROMEditor

Namespace NDS
    Public MustInherit Class BaseNDSRom
        Protected Sub New()
        End Sub
        Public Property ROM As GenericNDSRom
        Protected Property Saves As Dictionary(Of String, Object)
        Public Function GetSaves() As IEnumerable(Of Object)
            Return Saves.Values
        End Function
        Public Overrides Function ToString() As String
            If ROM IsNot Nothing Then
                Return String.Format("{0} ({1} saves).", ROM.ToString, Saves.Count)
            Else
                Return MyBase.ToString
            End If
        End Function
    End Class
End Namespace

