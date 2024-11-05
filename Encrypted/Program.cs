using System;

class Program
{
    static void Main()
    {
        Random random = new Random();

        while (true)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Encrypt a message with a specific key");
            Console.WriteLine("2. Encrypt a message with a random key");
            Console.WriteLine("3. Decrypt a message");
            Console.WriteLine("4. Exit");
            Console.Write("Your choice: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Enter the message to encrypt: ");
                string message = Console.ReadLine().ToUpper();

                int key;
                while (true)
                {
                    Console.Write("Enter an encryption key (1-26): ");
                    if (int.TryParse(Console.ReadLine(), out key) && key >= 1 && key <= 26)
                    {
                        break;
                    }
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 26.");
                }

                string encryptedMessage = EncryptMessage(message, key);
                Console.WriteLine("Encrypted Message: " + encryptedMessage);
            }
            else if (choice == "2")
            {
                Console.Write("Enter the message to encrypt: ");
                string message = Console.ReadLine().ToUpper();

                // Generate a random key between 1 and 26
                int randomKey = random.Next(1, 27);
                string encryptedMessage = EncryptMessage(message, randomKey);
                Console.WriteLine($"Encrypted Message with key {randomKey}: " + encryptedMessage);
            }
            else if (choice == "3")
            {
                Console.Write("Enter the encrypted message: ");
                string encryptedMessage = Console.ReadLine().ToUpper();

                int key;
                while (true)
                {
                    Console.Write("Enter the decryption key (1-26): ");
                    if (int.TryParse(Console.ReadLine(), out key) && key >= 1 && key <= 26)
                    {
                        break;
                    }
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 26.");
                }

                string decryptedMessage = DecryptMessage(encryptedMessage, key);
                Console.WriteLine("Decrypted Message: " + decryptedMessage);
            }
            else if (choice == "4")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }

    static string EncryptMessage(string message, int key)
    {
        char[] buffer = message.ToCharArray();

        for (int i = 0; i < buffer.Length; i++)
        {
            char letter = buffer[i];

            if (char.IsUpper(letter))
            {
                int normalizedLetter = letter - 'A';

                int shiftedLetter = (normalizedLetter + key) % 26;

                letter = (char)(shiftedLetter + 'A');
            }

            buffer[i] = letter;
        }

        return new string(buffer);
    }

    static string DecryptMessage(string message, int key)
    {
        char[] buffer = message.ToCharArray();

        for (int i = 0; i < buffer.Length; i++)
        {
            char letter = buffer[i];

            if (char.IsUpper(letter))
            {

                int normalizedLetter = letter - 'A';

                int shiftedLetter = (normalizedLetter - key + 26) % 26;

                letter = (char)(shiftedLetter + 'A');
            }

            buffer[i] = letter;
        }

        return new string(buffer);
    }
}
