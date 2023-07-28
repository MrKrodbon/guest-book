<template>
    <ul>
        <li>
            <Comment v-for="comment of  commentsList"
                      :key="comment.id"
                     v-bind:commentItem="comment" />
        </li>
    </ul>
    
</template>

<script>
    import Comment from '@/components/Comment'
    export default {
        props:['commentsList'],
        components: {
            Comment
        }
    }
</script>

<style scoped>
    ul{
        list-style:none;
        margin:0;
        padding:0;
    }
    li {
        border: 1px solid #ccc;
        display: flex;
        justify-content: space-between;
        padding: .5rem 2rem;
        margin-bottom: 1rem;
    }
</style>