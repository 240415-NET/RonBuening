## Models
- User
    - userID (int)
- Common fields (Item Class)
    - itemID (int/GUID)
    - Owner (int)
    - Item Category (string)
    - Original cost (double)
    - Purchase date (DateTime)
    - Description (string)
- Pets (extending Item)
    - Name (string)
    - Species (string)
    - Age (int)
- Documents (extending Item)
    - Document Type (string)
    - Expiration (DateTime)