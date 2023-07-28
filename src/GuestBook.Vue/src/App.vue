<template>
    <div id="app">
        <h1>Guest Book</h1>
        <AddComment>
            @add-comment:"addComment"
        </AddComment>
        <GuestBookHeading />
        <GuestBookCommentsList v-bind:commentsList="comments" />
    </div>
</template>

<script src="https://cdnjs.cloudflare.com/ajax/libs/axios/1.4.0/axios.min.js" integrity="sha512-uMtXmF28A2Ab/JJO2t/vYhlaa/3ahUOgj1Zf27M5rOo8/+fcTUVH0/E0ll68njmjrLqOBjXM3V9NiPFL5ywWPQ==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
<script>
    import GuestBookCommentsList from '@/components/GuestBookCommentsList'
    import AddComment from '@/components/AddComment'

    const API_URL = "https://localhost:5000/";
    export default {
        name: 'App',
        data() {
            return {
                comments: []
            }
        },
        methods: {
            async refreshData() {
                axios.get(API_URL +"api/GuestBook/comment?Id=1").then(
                    (response) => {
                        this.comments = response.data;
                    }
                )
            }
            addComment(comment) {
                this.comments.push(comment)
            }
        },
        mounted: function () {
            this.refreshData();
        },
        components: {
            GuestBookCommentsList,
            AddComment
        }
    }
</script>

<style>
    #app {
      font-family: Avenir, Helvetica, Arial, sans-serif;
      -webkit-font-smoothing: antialiased;
      -moz-osx-font-smoothing: grayscale;
      display:block;
    }
    h1 {
        color: white;
        font-family: Helvetica, Arial, sans-serif;
    }
</style>
