Imports SkyEditor.Core

Public Module SettingsExtensions
    <Extension> Public Function GetNDSRomLibraryPath(provider As ISettingsProvider) As String
        Return provider.GetSetting(My.Resources.SettingsNames.NDSROMLibraryPath)
    End Function

    <Extension> Public Sub SetNDSRomLibraryPath(provider As ISettingsProvider, value As String)
        provider.SetSetting(My.Resources.SettingsNames.NDSROMLibraryPath, value)
    End Sub
End Module
