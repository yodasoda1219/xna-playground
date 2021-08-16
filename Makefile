ifndef PYTHON_COMMAND
	PYTHON_COMMAND := python
endif
all: native-binaries managed-projects submodules
submodules:
	- git submodule update --init --recursive
managed-projects: submodules
	- dotnet build /property:GenerateFullPaths=true /consoleloggerparameters:NoSummary
native-binaries: managed-projects
	- $(PYTHON_COMMAND) copy-binaries.py