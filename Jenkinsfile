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
   }
}