namespace Contacts;

public class ContactsGenerator
{
  public ContactsGenerator()
  {
  }

  public List<Contact> GenerateContacts(int count)
  {
    // TODO: generate `count` contacts - without
    // filling up memory - maybe using IEnemerable ?
    Contact c1 = new("Alex", "contact-1@domain.tld");
    Contact c2 = new("Bev", "contact-2@domain.tld");
    return new List<Contact> { c1, c2 };
  }
}