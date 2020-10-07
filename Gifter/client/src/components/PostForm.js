
import React, { useState, useContext, useEffect } from "react";
import {
  Form,
  FormGroup,
  Card,
  CardBody,
  Label,
  Input,
  Button,
} from "reactstrap";
import { PostContext } from "../providers/PostProvider";
import { useHistory } from "react-router-dom";
import Post from "./Post";

const PostForm = () => {
  const { addPost } = useContext(PostContext);
  const [userProfileId, setUserProfileId] = useState("");
  const [imageUrl, setImageUrl] = useState("");
  const [title, setTitle] = useState("");
  const [caption, setCaption] = useState("");
  const [dateCreated, setDateCreated] = useState("");

  // Use this hook to allow us to programatically redirect users
  const history = useHistory();


//   let timeStamp = new Intl.DateTimeFormat("en", {
//     timeStyle: "medium",
//     dateStyle: "short"
//   });

  const submit = (e) => {
    const post = {
      imageUrl,
      title,
      caption,
      userProfileId: +userProfileId,
      dateCreated //: timeStamp.format(Date.now())
    };



    addPost(post).then((p) => {
      // Navigate the user back to the home route
      history.push("/");
    });
  };

  // const submitForm = (e) => {
  //   e.preventDefault();
  //   addQuote({ text: quoteText })
  //     .then(() => history.push("/"))
  //     .catch((err) => alert(`An error ocurred: ${err.message}`));
  // };

  return (
    <div className="container pt-4">
      <div className="row justify-content-center">
        <Card className="col-sm-12 col-lg-6">
          <CardBody>
            <Form>
              <FormGroup>
                <Label for="userId">User Id (For Now...)</Label>
                <Input
                  id="userId"
                  onChange={(e) => setUserProfileId(e.target.value)}
                />
              </FormGroup>
              <FormGroup>
                <Label for="dateCreated">Date (For Now...)</Label>
                <Input
                    type = "datetime-local"
                  id="dateCreated"
                  onChange={(e) => setDateCreated(e.target.value)}
                />
              </FormGroup>
              <FormGroup>
                <Label for="imageUrl">Gif URL</Label>
                <Input
                  id="imageUrl"
                  onChange={(e) => setImageUrl(e.target.value)}
                />
              </FormGroup>
              <FormGroup>
                <Label for="title">Title</Label>
                <Input id="title" onChange={(e) => setTitle(e.target.value)} />
              </FormGroup>
              <FormGroup>
                <Label for="caption">Caption</Label>
                <Input
                  id="caption"
                  onChange={(e) => setCaption(e.target.value)}
                />
              </FormGroup>
            </Form>
            <Button color="info" onClick={submit}>
              SUBMIT
            </Button>
          </CardBody>
        </Card>
      </div>
    </div>
  );
};

export default PostForm;



// import { PostProvider } from "../providers/PostProvider";
// import React, { useContext, useEffect } from "react";
// import { PostContext } from "../providers/PostProvider";
// import Post from "./Post";

// const PostForm = () => {
//   const { post, getAllPosts, addPost } = useContext(PostContext);

//   useEffect(() => {
//     getAllPosts();
//     addPost(post);
//   }, []);



//     return (
//         <>

//             <div className="row">
//                 <div className="col s12 m5">
//                     <div className="card-panel transparent">
//                         <div className="row">
//                             <form id="addPost" className="col s12">

//                                 <div className="input-field col s5">
//                                     Title of the Entry:
//                 <input placeholder="Post Title..." id="post.Title" type="text" data-length="10" required
//                                          className="validate"></input>
//                                     <label for="Post"></label>
//                                 </div>

//                                         <button
//                                             className="waves-effect waves-light btn"
//                                             type="button"
                                           
//                                             onClick={addPost}
//                                         >Submit</button>
                               
//                             </form>
//                         </div>
//                     </div>
//                 </div>
//           </div>
//         </>
//     );
// };

// export default PostForm;
