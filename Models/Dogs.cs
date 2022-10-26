using System.Text.Json;
using System.Text.Json.Serialization;

namespace Models
{

    public class Message
    {
        public List<object> affenpinscher { get; }
        public List<object> african { get; }
        public List<object> airedale { get; }
        public List<object> akita { get; }
        public List<object> appenzeller { get; }
        public List<string> australian { get; }
        public List<object> basenji { get; }
        public List<object> beagle { get; }
        public List<object> bluetick { get; }
        public List<object> borzoi { get; }
        public List<object> bouvier { get; }
        public List<object> boxer { get; }
        public List<object> brabancon { get; }
        public List<object> briard { get; }
        public List<string> buhund { get; }
        public List<string> bulldog { get; }
        public List<string> bullterrier { get; }
        public List<string> cattledog { get; }
        public List<object> chihuahua { get; }
        public List<object> chow { get; }
        public List<object> clumber { get; }
        public List<object> cockapoo { get; }
        public List<string> collie { get; }
        public List<object> coonhound { get; }
        public List<string> corgi { get; }
        public List<object> cotondetulear { get; }
        public List<object> dachshund { get; }
        public List<object> dalmatian { get; }
        public List<string> dane { get; }
        public List<string> deerhound { get; }
        public List<object> dhole { get; }
        public List<object> dingo { get; }
        public List<object> doberman { get; }
        public List<string> elkhound { get; }
        public List<object> entlebucher { get; }
        public List<object> eskimo { get; }
        public List<string> finnish { get; }
        public List<string> frise { get; }
        public List<object> germanshepherd { get; }
        public List<object> golden { get; }
        public List<string> greyhound { get; }
        public List<object> groenendael { get; }
        public List<object> havanese { get; }
        public List<string> hound { get; }
        public List<object> husky { get; }
        public List<object> keeshond { get; }
        public List<object> kelpie { get; }
        public List<object> komondor { get; }
        public List<object> kuvasz { get; }
        public List<object> labradoodle { get; }
        public List<object> labrador { get; }
        public List<object> leonberg { get; }
        public List<object> lhasa { get; }
        public List<object> malamute { get; }
        public List<object> malinois { get; }
        public List<object> maltese { get; }
        public List<string> mastiff { get; }
        public List<object> mexicanhairless { get; }
        public List<object> mix { get; }
        public List<string> mountain { get; }
        public List<object> newfoundland { get; }
        public List<object> otterhound { get; }
        public List<string> ovcharka { get; }
        public List<object> papillon { get; }
        public List<object> pekinese { get; }
        public List<object> pembroke { get; }
        public List<string> pinscher { get; }
        public List<object> pitbull { get; }
        public List<string> pointer { get; }
        public List<object> pomeranian { get; }
        public List<string> poodle { get; }
        public List<object> pug { get; }
        public List<object> puggle { get; }
        public List<object> pyrenees { get; }
        public List<object> redbone { get; }
        public List<string> retriever { get; }
        public List<string> ridgeback { get; }
        public List<object> rottweiler { get; }
        public List<object> saluki { get; }
        public List<object> samoyed { get; }
        public List<object> schipperke { get; }
        public List<string> schnauzer { get; }
        public List<string> segugio { get; }
        public List<string> setter { get; }
        public List<object> sharpei { get; }
        public List<string> sheepdog { get; }
        public List<object> shiba { get; }
        public List<object> shihtzu { get; }
        public List<string> spaniel { get; }
        public List<string> springer { get; }
        public List<object> stbernard { get; }
        public List<string> terrier { get; }
        public List<object> tervuren { get; }
        public List<object> vizsla { get; }
        public List<string> waterdog { get; }
        public List<object> weimaraner { get; }
        public List<object> whippet { get; }
        public List<string> wolfhound { get; }

        public void Test() {
            Console.WriteLine("Test");
        }
    }

    public class DogsDto
    {

        public Message Message { get; }
        public string Status { get; }

        [JsonConstructor]
        public DogsDto(Message message, string status) 
        {
            Message = message ?? throw new ArgumentNullException(nameof(message));
            Status = status ?? throw new ArgumentNullException(nameof(status));
        }

        
    }
}