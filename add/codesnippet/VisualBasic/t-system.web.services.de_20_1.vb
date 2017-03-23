Imports System
Imports System.Web.Services.Description
Imports System.Collections
Imports System.Xml
Imports Microsoft.VisualBasic

Class MyClass1
   Public Shared Sub Main()
      Console.WriteLine("")
      Console.WriteLine("MessagePartCollection Sample")
      Console.WriteLine("============================")
      Console.WriteLine("")

      Dim myServiceDescription As ServiceDescription = _
         ServiceDescription.Read("MathService.wsdl")
      ' Get the message collection.
      Dim myMessageCollection As MessageCollection = _
         myServiceDescription.Messages
      Console.WriteLine("Total Messages in the document = " & _
         myServiceDescription.Messages.Count.ToString)
      Console.WriteLine("")
      Console.WriteLine("Enumerating PartCollection for each message...")
      Console.WriteLine("")
      ' Get the message part collection for each message.
      Dim i As Integer
      For i =0 to myMessageCollection.Count-1
         Console.WriteLine("Message      : " & myMessageCollection(i).Name)

         ' Get the message part collection.
         Dim myMessagePartCollection As MessagePartCollection = _
            myMessageCollection(i).Parts

         ' Display the part collection.
         Dim k As Integer
         For k = 0 To myMessagePartCollection.Count - 1
            Console.WriteLine(ControlChars.Tab & "       Part Name     : " & _
               myMessagePartCollection(k).Name)
            Console.WriteLine(ControlChars.Tab & "       Message Name  : " & _
               myMessagePartCollection(k).Message.Name)
         Next k
         Console.WriteLine("")
      Next
      Console.WriteLine("Displaying the array copied from the " & _
         "MessagePartCollection for the message AddHttpGetIn.")
      Dim myLocalMessage As Message = _
         myServiceDescription.Messages("AddHttpPostOut")
      If myMessageCollection.Contains(myLocalMessage) Then
         Console.WriteLine("Message      : " & myLocalMessage.Name)

         ' Get the message part collection.
         Dim myMessagePartCollection As MessagePartCollection = _
            myLocalMessage.Parts
         Dim myMessagePart(myMessagePartCollection.Count) As MessagePart

         ' Copy the MessagePartCollection to an array.
         myMessagePartCollection.CopyTo(myMessagePart, 0)
         Dim k As Integer
         For k = 0 To myMessagePart.Length - 2
            Console.WriteLine(ControlChars.Tab & "       Part Name : " & _
               myMessagePartCollection(k).Name)
         Next k
         Console.WriteLine("")
      End If

      Console.WriteLine("Checking if message is AddHttpPostOut...")
      Dim myMessage As Message = myServiceDescription.Messages("AddHttpPostOut")
      If myMessageCollection.Contains(myMessage) Then

         ' Get the message part collection.
         Dim myMessagePartCollection As MessagePartCollection = myMessage.Parts

         ' Get the part named Body.
         Dim myMessagePart As MessagePart = myMessage.Parts("Body")
         If myMessagePartCollection.Contains(myMessagePart) Then

            ' Get the index of the part named Body.
            Console.WriteLine("Index of Body in MessagePart collection = " & _
               myMessagePartCollection.IndexOf(myMessagePart).ToString)
            Console.WriteLine("Deleting Body from MessagePart Collection...")
            myMessagePartCollection.Remove(myMessagePart)
            If myMessagePartCollection.IndexOf(myMessagePart) = -1 Then
               Console.WriteLine("MessagePart Body successfully deleted " & _
               "from the message AddHttpPostOut.")
            End If
         End If
      End If
   End Sub 'Main
End Class '[MyClass1]