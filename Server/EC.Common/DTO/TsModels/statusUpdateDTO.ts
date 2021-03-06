
module Server.DTO {

    // $Classes/Enums/Interfaces(filter)[template][separator]
    // filter (optional): Matches the name or full name of the current item. * = match any, wrap in [] to match attributes or prefix with : to match interfaces or base classes.
    // template: The template to repeat for each matched item
    // separator (optional): A separator template that is placed between all templates e.g. $Properties[public $name: $Type][, ]

    // More info: http://frhagn.github.io/Typewriter/

    
    export class statusUpdateDTO {
        
        // USERID
        public userId: number = 0;
        // BASKETID
        public basketId: string = "00000000-0000-0000-0000-000000000000";
        // STATUS
        public status: BasketStatus = null;
    }  
}