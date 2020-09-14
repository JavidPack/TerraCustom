import fileinput

def TypicalReplace(filename, searchterm, result):
    for line in fileinput.input(filename, inplace=True):
        if line.startswith(searchterm):
            print(searchterm + result)
        else:
            print(line, end='')

versionInput = input("Enter new version number separated by periods ('0.1.2.3'):  ").strip()
versionList = versionInput.split('.')
#versionNums = [int(x) for x in versionList]

TypicalReplace("CompleteRelease.bat", "set TerraCustomVersion=v", versionInput)
TypicalReplace("../patches/TerraCustom/Terraria.ModLoader/ModLoader.cs", "\t\t\t\tstring drawVersion = Main.versionNumber + Environment.NewLine + ModLoader.ModLoader.versionedName + Environment.NewLine + \"jopojelly's TerraCustom v", versionInput + '" + (showPatreon ? Environment.NewLine + supportMessage : "");')

input("Press Enter to continue...")