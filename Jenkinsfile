properties([pipelineTriggers([githubPush()])])

pipeline {
    agent any

    stages {
        stage('hello') {
            steps {
                // Get some code from a GitHub repository
                echo 'hello'
            }
        }
        stage('deleteWorkspace') {
            steps {
                deleteDir()
            }
        }
        stage('clone') {
            steps {
                // Get some code from a GitHub repository
                git branch: 'master',
                url: 'https://github.com/pwujczyk/ProductivityTools.IdentityServer.git'
            }
        }
		stage('workplacePath'){
			steps{
				echo "${env.WORKSPACE}"
			}
		}
        stage('build') {
            steps {
                bat(script: "dotnet publish ProductivityTools.IdentityServer.sln -c Release", returnStdout: true)
            }
        }
        stage('stopMeetingsOnIis') {
            steps {
                bat('%windir%\\system32\\inetsrv\\appcmd stop site /site.name:IdentityServer')
            }
        }

        stage('deleteIisDir') {
            steps {
                retry(5) {
                    bat('if exist "C:\\Bin\\IdentityServer" RMDIR /Q/S "C:\\Bin\\IdentityServer"')
                }

            }
        }
        stage('copyIisFiles') {
            steps {
                bat('xcopy "C:\\Program Files (x86)\\Jenkins\\workspace\\IdentityServer\\ProductivityTools.IdentityServer\\bin\\Release\\netcoreapp3.1\\publish" "C:\\Bin\\IdentityServer\\" /O /X /E /H /K')
            }
        }

        stage('startMeetingsOnIis') {
            steps {
                bat('%windir%\\system32\\inetsrv\\appcmd start site /site.name:meetings')
            }
        }
        stage('byebye') {
            steps {
                // Get some code from a GitHub repository
                echo 'byebye'
            }
        }
    }
}
