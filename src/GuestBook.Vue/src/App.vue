<template>
    <div id="app">
        <h1>Guest Book</h1>
        <AddComment v-for="comment in comments"
                    :comment="comment"
                    :key="comment.id" />
        <GuestBookCommentsList v-bind:commentsList="comments" />
        @addComment="addComment"
    </div>
</template>

<script src="https://cdnjs.cloudflare.com/ajax/libs/axios/1.4.0/axios.min.js" integrity="sha512-uMtXmF28A2Ab/JJO2t/vYhlaa/3ahUOgj1Zf27M5rOo8/+fcTUVH0/E0ll68njmjrLqOBjXM3V9NiPFL5ywWPQ==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
<script>
    import GuestBookCommentsList from '@/components/GuestBookCommentsList'
    import AddComment from '@/components/AddComment'
    export default {
        name: 'App',
        data() {
            return {
                loading: true,
                comments: []
            }
        },
        methods: {
            addComment(comment) {
                fetch('/api/comments',
                    {
                        method: 'POST',
                        headers: {
                            'content-type': 'application/json'
                        },
                        body: JSON.stringify(comment)
                    })
                    .then(response => response.json())
                    .then(data => {
                        if (data.id !== undefined) this.comments.push(data)
                    })
            }
        },
        mounted: {
            fetch('/api/comments')
                .then(response => response.json())
                .then(data => {
                    this.comments = data
                    this.loading = false
                })
            
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
